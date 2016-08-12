using System;
using UIKit;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSOAPClient
{
	public partial class BusinessObjectViewController : UIViewController
	{
		protected BusinessObjectViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CherwellServiceAPI api = new CherwellServiceAPI();
			await api.getLogin();

			List<BusinessObjectItem> itemElements = new List<BusinessObjectItem>();
			itemElements =  await api.getTabBarOptions();

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height - 30),
				Source = new BusinessObjectTableSource(itemElements) //need a foreach to go through itemElements
			};

			((BusinessObjectTableSource)table.Source).TheStinkingRowWasSelected += (sender, e) => {
				BusinessObjectItem businessObjectItem = ((BusinessObjectItemEventArgs)e).Item;
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

