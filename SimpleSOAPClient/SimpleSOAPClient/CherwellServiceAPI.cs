﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace SimpleSOAPClient
{
	public class CherwellServiceAPI
	{

		string serviceURL = "http://172.31.0.192/cherwellservice/api.asmx";

		public CherwellServiceAPI()
		{
		}

		async public Task<string> getLogin()
		{
			


			//SOAPRequest request = new SOAPRequest(serviceURL, "GetServiceInfo");
			//string response = await request.GetResponse();

			SOAPRequest request = new SOAPRequest(serviceURL, "MobileLogin");
			request.AddParam(new SOAPParam("userId", "Henri"));
			request.AddParam(new SOAPParam("password", "password"));
			request.AddParam(new SOAPParam("version", ""));
			request.AddParam(new SOAPParam("sessionId", ""));
			request.AddParam(new SOAPParam("preferences", ""));
			request.AddParam(new SOAPParam("useSAML", false));
			string response = await request.GetResponse();
			return response;
		}

		async public Task<List<ItemListItem>> getItemList(string objectType, string objectNameorId, string currentLocation, bool forceRefresh)
		{
			SOAPRequest request = new SOAPRequest(serviceURL, "GetItemList");
			request.AddParam(new SOAPParam("objectType", objectType));
			request.AddParam(new SOAPParam("objectNameOrId", objectNameorId));
			request.AddParam(new SOAPParam("currentLocation", currentLocation));
			request.AddParam(new SOAPParam("forceRefresh", forceRefresh));
			string response = await request.GetResponse();

			string str = "GetItemListResult";
			int startPos = response.IndexOf("<" + str + ">", StringComparison.InvariantCulture);
			startPos = startPos + str.Length + 2;
			int endPos = response.IndexOf("</" + str + ">", StringComparison.InvariantCulture);

			string getItemListResult = response.Substring(startPos, endPos - startPos);
			getItemListResult = HttpUtility.HtmlDecode(getItemListResult);

			XDocument doc = XDocument.Parse(getItemListResult);
			var elements = doc.Root.Elements();

			List<ItemListItem> itemElements = new List<ItemListItem>();
			foreach (var element in elements)
			{
				//getting the attributes
				var itemTypeAttribute = element.Attribute("ItemType").Value;
				var itemIdAttrivute = element.Attribute("ItemId").Value;
				var currentLocationAttribute = element.Attribute("CurrentLocation").Value;
				var defTypeAttribute = element.Attribute("DefType").Value;


				//getting the elements
				var displayTextElement = element.Element("DisplayText").Value;
				var displayDescription = element.Element("DisplayDescription").Value;
				var displayImageId = element.Element("DisplayImageId").Value;
				var itemElementsObject = new ItemListItem(defTypeAttribute, itemIdAttrivute, currentLocationAttribute, displayTextElement, itemTypeAttribute);
				itemElements.Add(itemElementsObject);
			}

			return itemElements;
		}

		async public Task<List<BusinessObjectItem>> getTabBarOptions()
		{
			SOAPRequest request = new SOAPRequest(serviceURL, "GetTabBarOptions");
			//request.AddParam(new SOAPParam("iPhoneImages", false));
			string response = await request.GetResponse();
			string s = "GetTabBarOptionsResult";
			int startPos = response.IndexOf("<" + s + ">", StringComparison.InvariantCulture); //280

			startPos = startPos + s.Length + 2;
			int endPos = response.IndexOf("</" + s + ">", StringComparison.InvariantCulture);  //3906
			string getTabBarOptionsResults = response.Substring(startPos, endPos - startPos);

			getTabBarOptionsResults = HttpUtility.HtmlDecode(getTabBarOptionsResults);

			XDocument doc = XDocument.Parse(getTabBarOptionsResults);
			var elements = doc.Root.Elements();

			List<BusinessObjectItem> itemElements = new List<BusinessObjectItem>();

			foreach (var element in elements)
			{
				var itemTypeAttribute = element.Attribute("ItemType").Value;
				var itemIdAttribute = element.Attribute("ItemId").Value;
				var cargoElement = element.Element("Cargo").Value;
				var itemDisplayTextElement = element.Element("ItemDisplayText").Value;
				var itemImageIdElement = element.Element("ItemImageId").Value;
				var busObDescriptionElement = element.Element("BusObDescription").Value;
				var itemElementsObject = new BusinessObjectItem (itemTypeAttribute, itemIdAttribute, cargoElement, itemDisplayTextElement, itemImageIdElement, busObDescriptionElement);
				itemElements.Add(itemElementsObject);

			}

			return itemElements;
		}


	}
}

