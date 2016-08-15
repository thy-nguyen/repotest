using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleSOAPClient
{
	public class AssociatedItemTableSource : UITableViewSource
	{
		List<AssociatedItem> tableItems = new List<AssociatedItem>();

		string cellIdentifier = "TableCell";
		public EventHandler TheStinkingRowWasSelected;

		public AssociatedItemTableSource(List<AssociatedItem> items) //change to List instead of string
		{
			tableItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].ItemDisplayText;
			cell.DetailTextLabel.Text = tableItems[indexPath.Row].BusObDescription;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			AssociatedItem item = new AssociatedItem();
			item.Cargo = tableItems[indexPath.Row].Cargo;
			//new UIAlertView("Alert", tableItems[indexPath.Row].Cargo, null, "OK", null).Show();
			//new UIAlertView("Alert", item.Cargo, null, "OK", null).Show();

			tableView.DeselectRow(indexPath, true);


			TheStinkingRowWasSelected(this, new AssociatedItemEventArgs(tableItems[indexPath.Row]));

		}

	}
}

