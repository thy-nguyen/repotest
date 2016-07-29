using System;
using System.Collections.Generic;
using System.Diagnostics;
using LNB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LNBTests
{
	[TestClass]
	public class LNBUnitTest
	{
		// Experimenting with TestContext. Possibly useful but has odd setup.
		private TestContext testContextInstance;
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void GoldenPathTest()
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = 2348;
			var expectedResults = new Dictionary<int, int> {{1000, 2}, {100, 3}, {10, 4}, {5, 1}, {2, 1}, {1, 1}};
				
			Stopwatch stopwatch = Stopwatch.StartNew();
			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);
			stopwatch.Stop();

			/*
				Just showing several ways of testing. #3 seems most reliable and easiest to maintain.
			*/ 

			// Approach #1
			// The following test is less tedious and confirms the bills total to the original amount but it doesn't fully verify the expected denominations and counts.
			Assert.AreEqual(6, results.Count, "Incorrect # of denominations");
			int total = 0;
			foreach (var key in results.Keys)
				total += ((int)key * (int)results[key]);
			Assert.AreEqual(amount, total, "Didn't add up correctly");

			// Approach #2
			// This thoroughly verifies expectations but is tedious and wordy. We could remove the message strings to tighten it up.
			Assert.AreEqual(6, results.Count, "Incorrect # of denominations");
			Assert.AreEqual(2, results[(object)1000], "Wrong thousands");
			Assert.AreEqual(3, results[(object)100], "Wrong hundreds");
			Assert.AreEqual(4, results[(object)10], "Wrong tens");
			Assert.AreEqual(1, results[(object)5], "Wrong fives");
			Assert.AreEqual(1, results[(object)2], "Wrong twos");
			Assert.AreEqual(1, results[(object)1], "Wrong ones");

			// Approach #3
			// I prefer this way.
			Assert.AreEqual(expectedResults.Count, results.Count, "Incorrect # of denominations");
			foreach (var key in results.Keys)
				Assert.AreEqual(expectedResults[(int)key], results[key], $"Mismatch on {key}'s.");


			// If we got to here. The tests must have passed. Outputting timing.
			// Experimenting with TestContext since I've never used it.
			//TestContext.WriteLine("Test Name: " + TestContext.TestName);
			//TestContext.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}

		[TestMethod]
		public void ZeroAmountTest()
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = 0;

			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);

			Assert.IsNotNull(results);
			Assert.AreEqual(0, results.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UnsolvableDenominationsTest()
		{
			// No ones. Can't produce correct amount.
			int[] denom = { 500, 100, 50, 10, 5, 2, 1000 };
			int amount = 38;

			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NoDenominationsTest()
		{
			int[] denom = {};
			int amount = 500;

			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);
		}
	}
}
