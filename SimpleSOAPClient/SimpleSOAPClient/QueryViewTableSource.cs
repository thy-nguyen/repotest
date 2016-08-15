using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleSOAPClient
{
	public class QueryViewTableSource : UITableViewSource
	{
		List<QueryResultItem> tableItems = new List<QueryResultItem>();

		string cellIdentifier = "TableCell";
		public EventHandler TheStinkingRowWasSelected;

		public QueryViewTableSource(List<QueryResultItem> items)
		{
			tableItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].TitleText;
			cell.DetailTextLabel.Text = tableItems[indexPath.Row].BodyText;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			QueryResultItem tableItem = tableItems[indexPath.Row];
			TheStinkingRowWasSelected(this, new QueryResultItemEventArgs(tableItem));
		}

	}
}

