
using System;
using LNBiOS;
using NUnit.Framework;

namespace LNBTests
{
	[TestFixture]
	public class MyTest
	{
		[Test]
		public void Pass()
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = 0;
			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);

			Assert.IsNotNull(results);
			Assert.AreEqual(0, results.Count);
			//Assert.True(true);
		}

		[Test]
		public void Fail()
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1000 };
			int amount = 38;

			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);
			Assert.AreEqual(0, results.Count);
			//Assert.False(true);
		}

		[Test]
		[Ignore("another time")]
		public void Ignore()
		{
			Assert.True(false);
		}
	}
}
