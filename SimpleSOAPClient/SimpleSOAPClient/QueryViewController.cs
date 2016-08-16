using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace SimpleSOAPClient
{
    public partial class QueryViewController : UIViewController
    {
        public QueryViewController	 (IntPtr handle) : base (handle)
        {
        }
		public ItemListItem Item { get; set; }

		public QueryViewController(ItemListItem item)
		{
			Item = item;
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CherwellServiceAPI api = new CherwellServiceAPI();
			List<QueryResultItem> items = new List<QueryResultItem>();
			items = await api.getQueryResult(Item.ItemId);

			UITableView table;
			table = new UITableView
			{
				Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60),
				Source = new QueryViewTableSource(items)
			};

			((QueryViewTableSource)table.Source).TheStinkingRowWasSelected += (sender, e) =>
			{
				QueryResultItem queryResultItem = ((QueryResultItemEventArgs)e).Item;
				ItemListItem itemListItem = new ItemListItem(queryResultItem.TypeId, queryResultItem.RecId, "", "", "StoredQueryDef");
				BusinessObjectViewController vc = new BusinessObjectViewController(queryResultItem.TypeId, queryResultItem.RecId);
				NavigationController.PushViewController(vc, true);
			};

			View.AddSubview(table);
		}
    }
}