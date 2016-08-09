using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;

namespace SimpleSOAPClient
{
	public class SOAPRequest
	{
		private static CookieContainer cookieJar = new CookieContainer();

		public SOAPRequest(string serverURL, string methodName)
		{
			ServerUrl = serverURL;
			MethodName = methodName;
		}

		public string ServerUrl { get; set; }
		public string MethodName { get; set; }
		private List<SOAPParam> m_params = new List<SOAPParam>();

		public void AddParam(SOAPParam param)
		{
			m_params.Add(param);
		}

		async public Task<string> GetResponse()
		{
			const string xsiNS = "http://www.w3.org/2001/XMLSchema-instance";
			const string xsdNS = "http://www.w3.org/2001/XMLSchema";
			const string soapNS = "http://schemas.xmlsoap.org/soap/envelope/";
			const string cherwellNS = "http://cherwellsoftware.com";

			var settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = Encoding.UTF8;
			MemoryStream ms = new MemoryStream();
			XmlWriter xw = XmlWriter.Create(ms, settings);
			xw.WriteStartDocument();
			xw.WriteStartElement("soap", "Envelope", soapNS);
			xw.WriteAttributeString("xmlns", "xsi", null, xsiNS);
			xw.WriteAttributeString("xmlns", "xsd", null, xsdNS);
			xw.WriteAttributeString("xmlns", "soap", null, soapNS);
			xw.WriteStartElement("Body", soapNS);

			xw.WriteStartElement(MethodName, cherwellNS);
			foreach (SOAPParam param in m_params)
			{
				//xw.WriteStartElement(param.Name); //figure why this is a problem <localname 
				xw.WriteElementString(param.Name, param.GetValueAsString());
				//xw.WriteEndElement();

			}
			xw.WriteEndElement();   // method

			xw.WriteEndElement();   // Body
			xw.WriteEndElement();   // Envelope
			xw.Close();
			ms.Close();

			string test = ms.ToString();
			byte[] bodyData = ms.ToArray();

			WebRequest request = WebRequest.Create(ServerUrl);
			((HttpWebRequest)request).CookieContainer = cookieJar;
			request.ContentType = "text/xml; charset=utf-8";
			request.Headers.Add("SOAPAction", cherwellNS + "/" + MethodName);

			request.Method = "POST";
			request.ContentLength = bodyData.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(bodyData, 0, bodyData.Length);
			dataStream.Close();


			WebResponse response = await request.GetResponseAsync();
			var statusCode = ((HttpWebResponse)response).StatusCode;
			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream);
			string responseString = reader.ReadToEnd();
			reader.Close();
			responseStream.Close();

			return responseString;
		}
	}
}
