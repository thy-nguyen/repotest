using System;

using UIKit;

namespace LNBiOS
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

		partial void BtnLNB_TouchUpInside(UIButton sender)
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = Convert.ToInt32(txtAmount.Text);
			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);

			foreach (var key in results.Keys)
				txtResults.Text += $"{results[key]:N0}....{key:N0}'s" + "\n";
		}

	}


}

