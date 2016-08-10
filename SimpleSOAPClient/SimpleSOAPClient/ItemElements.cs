using System;
namespace SimpleSOAPClient
{
	public class ItemElements
	{
		public string ItemType { get; private set; }
		public string ItemId { get; private set; }
		public string Cargo { get; private set; }
		public string ItemDisplayText { get; private set; }
		public string ItemImageId { get; private set; }
		public string BusObDescription { get; private set; }

		public string DefType { get; private set; }
		public string ObjectId { get; private set; }
		public string CurrentLocation { get; private set; }
		public bool ForceRefresh { get; private set; }

		public ItemElements(string itemType, string itemId, string cargo, string itemDisplayText, string itemImageId, string busObDescription)
		{
			ItemType = itemType;
			ItemId = itemId;
			Cargo = cargo;
			ItemDisplayText = itemDisplayText;
			ItemImageId = itemImageId;
			BusObDescription = busObDescription;
		}

		public ItemElements(string defType, string objectId, string currentLocation, bool forceRefresh)
		{
			DefType = defType;
			ObjectId = ObjectId;
			CurrentLocation = currentLocation;
			ForceRefresh = forceRefresh;
		}

	}
}

