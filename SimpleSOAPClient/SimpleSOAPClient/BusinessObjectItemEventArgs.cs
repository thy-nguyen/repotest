using System;
namespace SimpleSOAPClient
{
	public class BusinessObjectItemEventArgs : EventArgs
	{
		public BusinessObjectItem Item { get; private set; }

		public BusinessObjectItemEventArgs(BusinessObjectItem item)
		{
			Item = item;
		}
	}
}

