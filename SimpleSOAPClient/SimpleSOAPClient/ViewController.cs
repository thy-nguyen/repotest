using System;
using UIKit;
using System.Net.Http;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSOAPClient
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CherwellServiceAPI api = new CherwellServiceAPI();
			await api.getLogin();

			// Perform any additional setup after loading the view, typically from a nib.
			List<ItemElements> itemElements = new List<ItemElements>();
			itemElements =  await api.getTabBarOptions();

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 30, View.Bounds.Width, View.Bounds.Height - 30),
				Source = new TableSource(itemElements) //need a foreach to go through itemElements
			};

			View.AddSubview(table);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

	}
}

