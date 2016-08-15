﻿using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleSOAPClient
{
	public class ItemListTableSource : UITableViewSource
	{
		List<ItemListItem> tableItems = new List<ItemListItem>();

		string cellIdentifier = "TableCell";
		public EventHandler TheStinkingRowWasSelected;

		public ItemListTableSource(List<ItemListItem> items)
		{
			tableItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].DisplayText;
			cell.DetailTextLabel.Text = "";
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			ItemListItem tableItem = tableItems[indexPath.Row];
			TheStinkingRowWasSelected(this, new ItemListItemEventArgs(tableItem));
		}

	}
}
