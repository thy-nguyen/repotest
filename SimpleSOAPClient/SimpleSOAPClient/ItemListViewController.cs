using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace SimpleSOAPClient
{
    public partial class ItemListViewController	 : UIViewController
    {
		private ItemListItem m_item;

		public ItemListViewController(ItemListItem item)
		{
			m_item = item;
		}

		public ItemListViewController	 (IntPtr handle) : base (handle)
        {
        }

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CherwellServiceAPI api = new CherwellServiceAPI();

			List<ItemListItem> itemElements = new List<ItemListItem>();
			itemElements = await api.getItemList(m_item.DefType, m_item.ItemId, m_item.CurrentLocation, false);

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60),
				Source = new ItemListTableSource(itemElements)
			};

			((ItemListTableSource)table.Source).TheStinkingRowWasSelected += (sender, e) =>
			{
				ItemListItem item = ((ItemListItemEventArgs)e).Item;
				if (item.ItemType == "Folder")
				{
					ItemListViewController vc = new ItemListViewController(item);
					NavigationController.PushViewController(vc, true);
				}
				else if (item.ItemType == "StoredQueryDef")
				{
					QueryViewController vc = new QueryViewController(item);
					NavigationController.PushViewController(vc, true);
					//CherwellServiceAPI api = new CherwellServiceAPI();
					//List<QueryResultItem> item = new List<QueryResultItem>();
					//item = api.getQueryResult(tableItem.ItemId);
					//List<QueryResultItem> queryItemElement = new List<QueryResultItem>();
					//queryItemElement = await api.getQueryResult(m_item.ItemId);
					//ItemListViewController vc = new ItemListViewController(queryItemElement);
					//NavigationController.PushViewController(vc, true);
				}

			};

			View.AddSubview(table);

		}

    }
}