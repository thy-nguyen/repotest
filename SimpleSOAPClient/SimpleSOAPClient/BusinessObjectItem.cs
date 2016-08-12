using System;
namespace SimpleSOAPClient
{
	public class BusinessObjectItem
	{
		public string ItemType { get; private set; }
		public string ItemId { get; private set; }
		public string Cargo { get; set; }
		public string ItemDisplayText { get; private set; }
		public string ItemImageId { get; private set; }
		public string BusObDescription { get; private set; }

		public BusinessObjectItem(string itemType, string itemId, string cargo, string itemDisplayText, string itemImageId, string busObDescription)
		{
			ItemType = itemType;
			ItemId = itemId;
			Cargo = cargo;
			ItemDisplayText = itemDisplayText;
			ItemImageId = itemImageId;
			BusObDescription = busObDescription;
		}

		public BusinessObjectItem()
		{
		}
	}
}

