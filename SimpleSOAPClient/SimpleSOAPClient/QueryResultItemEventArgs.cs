using System;

namespace SimpleSOAPClient
{
	class QueryResultItemEventArgs : EventArgs
	{
		public QueryResultItem Item;

		public QueryResultItemEventArgs(QueryResultItem item)
		{
			Item = item;
		}
	}
}