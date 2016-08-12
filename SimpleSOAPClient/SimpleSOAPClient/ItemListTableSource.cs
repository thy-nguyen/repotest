using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleSOAPClient
{
	public class ItemListTableSource : UITableViewSource
	{
		//string[] tableItems; //change to List instead of string
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
			//base.RowSelected(tableView, indexPath);

			//CherwellServiceAPI api = new CherwellServiceAPI();
			//await api.getLogin();
			//await api.getItemList(tableItems[indexPath.Row].ItemType, tableItems[indexPath.Row].ItemId, "", false);

			//pass value to Cargo
			//ItemElements item = new ItemElements();
			//item.Cargo = tableItems[indexPath.Row].Cargo;
			//new UIAlertView("Alert", tableItems[indexPath.Row].Cargo, null, "OK", null).Show();
			//new UIAlertView("Alert", item.Cargo, null, "OK", null).Show();

			//tableView.DeselectRow(indexPath, true);


			TheStinkingRowWasSelected(this, new ItemListItemEventArgs(tableItems[indexPath.Row]));


			//GetListItemVC controller = this.Storyboard.InstantiateViewController("GetListItemVC") as GetListItemVC;
			//this.NavigationController.PushViewController(controller, true);

		}

	}
}

