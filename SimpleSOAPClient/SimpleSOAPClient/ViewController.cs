using System;
using UIKit;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSOAPClient
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			List<ItemElements> itemElements = new List<ItemElements>();
			itemElements = await getItemElements();

			// Perform any additional setup after loading the view, typically from a nib.
			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height - 30),
				Source = new TableSource(itemElements) //need a foreach to go through itemElements
			};

			View.AddSubview(table);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

		async public Task<List<ItemElements>> getItemElements()
		{
			string serviceURL = "http://172.31.0.144/cherwellservice/api.asmx";


			SOAPRequest request = new SOAPRequest(serviceURL, "GetServiceInfo");
			string response = await request.GetResponse();

			request = new SOAPRequest(serviceURL, "MobileLogin");
			request.AddParam(new SOAPParam("userId", "Henri"));
			request.AddParam(new SOAPParam("password", "password"));
			request.AddParam(new SOAPParam("version", ""));
			request.AddParam(new SOAPParam("sessionId", ""));
			request.AddParam(new SOAPParam("preferences", ""));
			request.AddParam(new SOAPParam("useSAML", false));
			response = await request.GetResponse();

			request = new SOAPRequest(serviceURL, "GetTabBarOptions");
			//request.AddParam(new SOAPParam("iPhoneImages", false));
			response = await request.GetResponse();
			string s = "GetTabBarOptionsResult";
			int startPos = response.IndexOf("<" + s + ">", StringComparison.InvariantCulture); //280

			startPos = startPos + s.Length + 2;
			int endPos = response.IndexOf("</" + s + ">", StringComparison.InvariantCulture);  //3906
			string getTabBarOptionsResults = response.Substring(startPos, endPos - startPos);

			getTabBarOptionsResults = HttpUtility.HtmlDecode(getTabBarOptionsResults);

			XDocument doc = XDocument.Parse(getTabBarOptionsResults);
			var elements = doc.Root.Elements();

			List<ItemElements> itemElements = new List<ItemElements>();

			foreach (var element in elements)
			{
				var cargoElement = element.Element("Cargo").Value;
				var itemDisplayTextElement = element.Element("ItemDisplayText").Value;
				var itemImageIdElement = element.Element("ItemImageId").Value;
				var busObDescriptionElement = element.Element("BusObDescription").Value;
				var itemElementsObject = new ItemElements(cargoElement, itemDisplayTextElement, itemImageIdElement, busObDescriptionElement);
				itemElements.Add(itemElementsObject);

			}

			return itemElements;

		}

		//async partial void UIButton3_TouchUpInside(UIButton sender)
		//{
		//	string serviceURL = "http://172.31.0.144/cherwellservice/api.asmx";


		//	SOAPRequest request = new SOAPRequest(serviceURL, "GetServiceInfo");
		//	string response = await request.GetResponse();

		//	request = new SOAPRequest(serviceURL, "MobileLogin");
		//	request.AddParam(new SOAPParam("userId", "Henri"));
		//	request.AddParam(new SOAPParam("password", "password"));
		//	request.AddParam(new SOAPParam("version", ""));
		//	request.AddParam(new SOAPParam("sessionId", ""));
		//	request.AddParam(new SOAPParam("preferences", ""));
		//	request.AddParam(new SOAPParam("useSAML", false));
		//	response = await request.GetResponse();

		//	request = new SOAPRequest(serviceURL, "GetTabBarOptions");
		//	//request.AddParam(new SOAPParam("iPhoneImages", false));
		//	response = await request.GetResponse();
		//	string s = "GetTabBarOptionsResult";
		//	int startPos = response.IndexOf("<" + s + ">", StringComparison.InvariantCulture); //280

		//	startPos = startPos + s.Length + 2;
		//	int endPos = response.IndexOf("</" + s + ">", StringComparison.InvariantCulture);  //3906
		//	string getTabBarOptionsResults = response.Substring(startPos, endPos - startPos);

		//	getTabBarOptionsResults = HttpUtility.HtmlDecode(getTabBarOptionsResults);

		//	XDocument doc = XDocument.Parse(getTabBarOptionsResults);
		//	var elements = doc.Root.Elements();

		//	List<ItemElements> itemElements = new List<ItemElements>();

		//	foreach (var element in elements)
		//	{
		//		var cargoElement = element.Element("Cargo").Value;
		//		var itemDisplayTextElement = element.Element("ItemDisplayText").Value;
		//		var itemImageIdElement = element.Element("ItemImageId").Value;
		//		var busObDescriptionElement = element.Element("BusObDescription").Value;
		//		var itemElementsObject = new ItemElements(cargoElement, itemDisplayTextElement, itemImageIdElement, busObDescriptionElement);
		//		itemElements.Add(itemElementsObject);

		//	}

		//}


	}
}

