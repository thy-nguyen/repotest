using System;
using System.Collections.Generic;

namespace SimpleSOAPClient
{
	public class QueryResultItem
	{
		public List<QueryResultItem> items;

		public string TypeId { get; set; }
		public string RecId { get; set; }
		public string TitleText { get; set; }
		public string BodyText { get; set; }

		public QueryResultItem(string typeId, string recId, string titleText, string bodyText)
		{
			TypeId = typeId;
			RecId = recId;
			TitleText = titleText;
			BodyText = bodyText;
		}
	}
}

