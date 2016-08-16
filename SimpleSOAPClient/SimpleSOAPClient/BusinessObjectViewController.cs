using Foundation;
using System;
using UIKit;
using WebKit;
using System.IO;

namespace SimpleSOAPClient
{
    public partial class BusinessObjectViewController : UIViewController
    {
		UIWebView webView;

		public BusinessObject m_businessObject;

		public string TypeId
		{
			get;
			set;
		}

		public string RecId
		{
			get;
			set;
		}

        public BusinessObjectViewController (IntPtr handle) : base (handle)
        {
        }

		public BusinessObjectViewController(string typeId, string recId)
		{
			TypeId = typeId;
			RecId = recId;
		}

		async public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CherwellServiceAPI api = new CherwellServiceAPI();
			m_businessObject = await api.getIndividualBusinessObject(TypeId, RecId);

			string contentDirectoryPath = Path.Combine(NSBundle.MainBundle.BundlePath, "/");
			webView = new UIWebView(View.Bounds);
			webView.ScalesPageToFit = true;
			//Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60)
			webView.Frame = new CoreGraphics.CGRect(0, 60, View.Bounds.Width, View.Bounds.Height - 60);

			View.AddSubview(webView);
			webView.LoadHtmlString(m_businessObject.DisplayHtml, new NSUrl(contentDirectoryPath));

		}
    }
}