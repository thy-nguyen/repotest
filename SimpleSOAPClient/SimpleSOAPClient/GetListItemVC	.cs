using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace SimpleSOAPClient
{
    public partial class GetListItemVC	 : UIViewController
    {
		private ItemElements m_item;

		public GetListItemVC(ItemElements item)
		{
			m_item = item;
		}

		public GetListItemVC	 (IntPtr handle) : base (handle)
        {
        }

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//ItemElements item = new ItemElements();

			CherwellServiceAPI api = new CherwellServiceAPI();
			//await api.getLogin();

			List<GetListItemElements> itemElements = new List<GetListItemElements>();
			itemElements = await api.getItemList(m_item.ItemType, m_item.Cargo, "", false);

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height - 30),
				Source = new ListViewSource(itemElements)
			};

			((ListViewSource)table.Source).TheStinkingRowWasSelected += (sender, e) =>
			{
				ItemElements item = ((ItemEventArgs)e).ItemElement;
				GetListItemVC vc = new GetListItemVC(item);
				NavigationController.PushViewController(vc, true);
			};

			View.AddSubview(table);

			//GetListItemVC controller = this.Storyboard.InstantiateViewController("GetListItemVC") as GetListItemVC;
			//this.NavigationController.PushViewController(controller, true);
		}

    }
}