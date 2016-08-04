using Android.App;
using Android.Widget;
using Android.OS;
using Shared;
using System;

namespace LNBAndroid
{
	[Activity(Label = "LNBAndroid", MainLauncher = true, Icon = "@mipmap/icon")]

	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button buttonCalc = FindViewById<Button>(Resource.Id.buttonCalc);
			EditText editTextAmount = FindViewById<EditText>(Resource.Id.editTextAmount);
			EditText editTextResults = FindViewById<EditText>(Resource.Id.editTextResults);

			buttonCalc.Click += (object sender, EventArgs e) =>
			{
				int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
				int amount = Convert.ToInt32(editTextAmount.Text);
				MoneyUtilities moneyUtilities = new MoneyUtilities();
				var results = moneyUtilities.DetermineLeastNumberOfBills(denom, amount);

				foreach (var key in results.Keys)
					editTextResults.Text += $"{results[key]:N0}....{key:N0}'s" + "\n";
			};
		}
	}
}

