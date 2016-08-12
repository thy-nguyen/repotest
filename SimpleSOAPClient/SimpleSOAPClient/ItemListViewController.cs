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

			//ItemElements item = new ItemElements();

			CherwellServiceAPI api = new CherwellServiceAPI();
			//await api.getLogin();

			List<ItemListItem> itemElements = new List<ItemListItem>();
			itemElements = await api.getItemList(m_item.DefType, m_item.ItemId, m_item.CurrentLocation, false);

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height - 30),
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
					
				}

			};

			View.AddSubview(table);

		}

    }
}