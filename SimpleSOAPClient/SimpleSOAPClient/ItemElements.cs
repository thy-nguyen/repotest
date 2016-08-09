using System;
namespace SimpleSOAPClient
{
	public class ItemElements
	{
		public string Cargo { get; private set; }
		public string ItemDisplayText { get; private set; }
		public string ItemImageId { get; private set; }
		public string BusObDescription { get; private set; }

		public ItemElements(string cargo, string itemDisplayText, string itemImageId, string busObDescription)
		{
			Cargo = cargo;
			ItemDisplayText = itemDisplayText;
			ItemImageId = itemImageId;
			BusObDescription = busObDescription;
		}
	}
}

