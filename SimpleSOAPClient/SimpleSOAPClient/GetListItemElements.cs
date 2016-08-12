using System;
namespace SimpleSOAPClient
{
	public class GetListItemElements
	{
		public string DefType { get; private set; }
		public string ObjectId { get; private set; }
		public string CurrentLocation { get; private set; }
		public bool ForceRefresh { get; private set; }
		public string DisplayText { get; private set; }

		public GetListItemElements(string defType, string objectId, string currentLocation, string displayText)
		{
			DefType = defType;
			ObjectId = objectId;
			CurrentLocation = currentLocation;
			DisplayText = displayText;
		}

		public GetListItemElements()
		{
		}
	}
}
