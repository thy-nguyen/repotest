using System;
namespace SimpleSOAPClient
{
	public class ItemListItem
	{
		public string DefType { get; private set; }
		public string ItemId { get; private set; }
		public string CurrentLocation { get; private set; }
		public bool ForceRefresh { get; private set; }
		public string DisplayText { get; private set; }
		public string ItemType { get; set; }

		public ItemListItem(string defType, string itemId, string currentLocation, string displayText, string itemType)
		{
			DefType = defType;
			ItemId = itemId;
			CurrentLocation = currentLocation;
			DisplayText = displayText;
			ItemType = itemType;
		}

		public ItemListItem()
		{
		}
	}
}
