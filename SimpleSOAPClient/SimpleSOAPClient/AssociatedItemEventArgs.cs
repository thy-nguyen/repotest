using System;
namespace SimpleSOAPClient
{
	public class AssociatedItemEventArgs : EventArgs
	{
		public AssociatedItem Item { get; private set; }

		public AssociatedItemEventArgs(AssociatedItem item)
		{
			Item = item;
		}
	}
}

