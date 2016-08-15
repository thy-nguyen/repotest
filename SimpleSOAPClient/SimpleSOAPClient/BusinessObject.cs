using System;
namespace SimpleSOAPClient
{
	public class BusinessObject
	{

		//var title = doc.Root.Element("Title").Value;
		//var displayHtml = doc.Root.Element("DisplayHtml").Value;
		//var displayImageId = doc.Root.Element("DisplayImageId").Value;
		//var locationElement = doc.Root.Element("Location");
		//var locationLat = locationElement.Attribute("lat").Value;
		//var locationLon = locationElement.Attribute("lon").Value;
		//var locationAlt

		public string Title
		{
			get;
			set;
		}

		public string DisplayHtml
		{
			get;
			set;
		}

		public string DisplayImageId
		{
			get;
			set;
		}

		public string LocationLat
		{
			get;
			set;
		}

		public string LocationLon
		{
			get;
			set;
		}

		public string LocationAlt
		{
			get;
			set;
		}

		public BusinessObject()
		{
		}


	}
}

