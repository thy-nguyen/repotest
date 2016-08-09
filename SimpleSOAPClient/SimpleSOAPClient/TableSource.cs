using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleSOAPClient
{
	public class TableSource : UITableViewSource
	{
		//string[] tableItems; //change to List instead of string
		List<ItemElements> tableItems = new List<ItemElements>();

		string cellIdentifier = "TableCell";

		public TableSource(List<ItemElements> items) //change to List instead of string
		{
			tableItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].ItemDisplayText;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

	}
}

