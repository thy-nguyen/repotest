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
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].ItemDisplayText;
			cell.DetailTextLabel.Text = tableItems[indexPath.Row].BusObDescription;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		async public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowSelected(tableView, indexPath);
			CherwellServiceAPI api = new CherwellServiceAPI();
			await api.getItemList(tableItems[indexPath.Row].ItemType, tableItems[indexPath.Row].ItemId, "", false);
			new UIAlertView("Alert", tableItems[indexPath.Row].Cargo, null, "OK", null).Show();

			tableView.DeselectRow(indexPath, true);
		}

	}
}

