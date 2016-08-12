using System;
namespace SimpleSOAPClient
{
	public class ItemEventArgs : EventArgs
	{
		public ItemElements ItemElement { get; private set; }

		public ItemEventArgs(ItemElements item)
		{
			ItemElement = item;
		}
	}
}

