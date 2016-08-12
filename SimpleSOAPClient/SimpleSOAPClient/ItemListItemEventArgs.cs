using System;
namespace SimpleSOAPClient
{
	public class ItemListItemEventArgs : EventArgs
	{
		public ItemListItem Item { get; private set; }

		public ItemListItemEventArgs(ItemListItem item)
		{
			Item = item;
		}
	}
}