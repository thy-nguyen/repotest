using System;
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

		/// <summary>
		/// Gets the individual business object.
		/// </summary>
		/// <returns>The individual business object.</returns>
		/// <param name="typeId">Type identifier.</param>
		/// <param name="recId">Rec identifier.</param>
		async public Task<BusinessObject> getIndividualBusinessObject(string typeId, string recId)
		{
			SOAPRequest request = new SOAPRequest(serviceURL, "GetItemDisplayHtml");
			request.AddParam(new SOAPParam("objectType", "StoreQueryDef"));
			request.AddParam(new SOAPParam("objectNameOrId", typeId));
			request.AddParam(new SOAPParam("recId", recId));
			request.AddParam(new SOAPParam("includeActions", false));
			request.AddParam(new SOAPParam("actionCargo", false));

			string response = await request.GetResponse();

			string str = "GetItemDisplayHtmlResult";
			int startPos = response.IndexOf("<" + str + ">", StringComparison.InvariantCulture);
			startPos = startPos + str.Length + 2;
			int endPos = response.IndexOf("</" + str + ">", StringComparison.InvariantCulture);

			string getItemDisplayHtmlResult = response.Substring(startPos, endPos - startPos);
			getItemDisplayHtmlResult = HttpUtility.HtmlDecode(getItemDisplayHtmlResult);

			XDocument doc = XDocument.Parse(getItemDisplayHtmlResult);

			var title = doc.Root.Element("Title").Value;
			var displayHtml = doc.Root.Element("DisplayHtml").Value;
			var displayImageId = doc.Root.Element("DisplayImageId").Value;
			var locationElement = doc.Root.Element("Location");
			var locationLat = locationElement.Attribute("lat").Value;
			var locationLon = locationElement.Attribute("lon").Value;
			var locationAlt = locationElement.Attribute("alt").Value;

			BusinessObject businessObject = new BusinessObject()
			{
				Title = title,
				DisplayHtml = displayHtml,
				DisplayImageId = displayImageId,
				LocationLat = locationLat,
				LocationLon = locationLon,
				LocationAlt = locationLon, 
			};

			return businessObject;


			                 
		}


		async public Task<List<QueryResultItem>> getQueryResult(string queryId)
		{
			SOAPRequest request = new SOAPRequest(serviceURL, "GetQueryResults");
			request.AddParam(new SOAPParam("queryId", queryId));
			request.AddParam(new SOAPParam("updateMru", false));
			request.AddParam(new SOAPParam("updateMru", false));
			request.AddParam(new SOAPParam("recordLimit", 200));
			request.AddParam(new SOAPParam("allowPromptInfo", false));
			request.AddParam(new SOAPParam("proximityThreshold", 0));
			request.AddParam(new SOAPParam("proximitySortAsc", true));

			string response = await request.GetResponse();
			string str = "GetQueryResultsResult";
			int startPos = response.IndexOf("<" + str + ">", StringComparison.InvariantCulture);
			startPos = startPos + str.Length + 2;
			int endPos = response.IndexOf("</" + str + ">", StringComparison.InvariantCulture);

			string getItemListResult = response.Substring(startPos, endPos - startPos);
			getItemListResult = HttpUtility.HtmlDecode(getItemListResult);

			XDocument doc = XDocument.Parse(getItemListResult);
			var elements = doc.Root.Elements();

			List<QueryResultItem> queryItems = new List<QueryResultItem>();
			foreach (var element in elements)
			{
				//getting the attributes
				var itemIdAttribute = element.Attribute("TypeId").Value;
				var recIdAttribute = element.Attribute("RecId").Value;
				var titleTextElement = element.Element("TitleText").Value;
				var BodyTextElement = element.Element("BodyText").Value;

				var queryItem = new QueryResultItem(itemIdAttribute, recIdAttribute, titleTextElement, BodyTextElement);
				queryItems.Add(queryItem);
			}

			return queryItems;

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

		async public Task<List<AssociatedItem>> getTabBarOptions()
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

			List<AssociatedItem> itemElements = new List<AssociatedItem>();

			foreach (var element in elements)
			{
				var itemTypeAttribute = element.Attribute("ItemType").Value;
				var itemIdAttribute = element.Attribute("ItemId").Value;
				var cargoElement = element.Element("Cargo").Value;
				var itemDisplayTextElement = element.Element("ItemDisplayText").Value;
				var itemImageIdElement = element.Element("ItemImageId").Value;
				var busObDescriptionElement = element.Element("BusObDescription").Value;
				var itemElementsObject = new AssociatedItem (itemTypeAttribute, itemIdAttribute, cargoElement, itemDisplayTextElement, itemImageIdElement, busObDescriptionElement);
				itemElements.Add(itemElementsObject);

			}

			return itemElements;
		}


	}
}

