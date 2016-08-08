using System;
using UIKit;

namespace SimpleSOAPClient
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		async partial void UIButton3_TouchUpInside(UIButton sender)
		{
			string serviceURL = "http://localhost/cherwellservice/api.asmx";

			SOAPRequest request = new SOAPRequest(serviceURL, "GetServiceInfo");
			string response = await request.GetResponse();

			request = new SOAPRequest(serviceURL, "MobileLogin");
			request.AddParam(new SOAPParam("userId", "Henri"));
			request.AddParam(new SOAPParam("password", "password"));
			request.AddParam(new SOAPParam("version", ""));
			request.AddParam(new SOAPParam("sessionId", ""));
			request.AddParam(new SOAPParam("preferences", ""));
			request.AddParam(new SOAPParam("useSAML", false));
			response = await request.GetResponse();

			request = new SOAPRequest(serviceURL, "GetTabBarOptions");
			request.AddParam(new SOAPParam("iPhoneImages", false));
			response = await request.GetResponse();

		}
	}
}

