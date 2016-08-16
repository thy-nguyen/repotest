using System;
using UIKit;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSOAPClient
{
	public partial class AssociatedItemViewController : UIViewController
	{
		protected AssociatedItemViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CherwellServiceAPI api = new CherwellServiceAPI();
			await api.getLogin();

			List<AssociatedItem> itemElements = new List<AssociatedItem>();
			itemElements =  await api.getTabBarOptions();

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60),
				Source = new AssociatedItemTableSource(itemElements) //need a foreach to go through itemElements
			};

			((AssociatedItemTableSource)table.Source).TheStinkingRowWasSelected += (sender, e) => {
				AssociatedItem businessObjectItem = ((AssociatedItemEventArgs)e).Item;
				ItemListItem itemListItem = new ItemListItem(businessObjectItem.ItemType, businessObjectItem.ItemId, "", "", "Folder");
				ItemListViewController vc = new ItemListViewController(itemListItem);
				NavigationController.PushViewController(vc, true);
			};


			View.AddSubview(table);

		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

	}
}

