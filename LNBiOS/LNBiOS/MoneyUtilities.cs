using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LNBiOS
{
	/// <summary>
	/// Utility methods useful for a cashier.
	/// </summary>
	public class MoneyUtilities
	{
		/// <summary>
		/// Determines the least number of bills needed to produce the provided amount.
		/// </summary>
		/// <param name="denom">Array of available denominations</param>
		/// <param name="amount">Amount the bills must add up to</param>
		/// <returns>Ordered keypairs (desc) and only for denoms used. Key: denom. Value: # of bills.</returns>
		/// <remarks>
		/// To be more realistic, it'd be interesting to modify the parameters so the number of available bills for each denomination is specified.
		/// </remarks>
		public static OrderedDictionary DetermineLeastNumberOfBills(int[] denom, int amount)
		{
			int[] sortedDenoms = denom.OrderByDescending(i => (int)i).ToArray();

			var results = new OrderedDictionary();
			foreach (var currDenom in sortedDenoms)
			{
				int numOfBills = Math.DivRem(amount, currDenom, out amount);
				if (numOfBills > 0)
					results.Add(currDenom, numOfBills);
			}

			// Uncomment the following and TestUnsolvableDenominationsTest will pass.
			if (amount != 0)
				throw new ArgumentException();

			return results;
		}
	}
}
