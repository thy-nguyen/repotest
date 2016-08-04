using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Shared
{
	public class MoneyUtilities
	{
		public Dictionary<int, int> DetermineLeastNumberOfBills(int[] denom, int amount)
		{
			int[] sortedDenoms = denom.OrderByDescending(i => (int)i).ToArray();

			var results = new Dictionary<int, int>();
			foreach (var currDenom in sortedDenoms)
			{
				int numOfBills = DivRem(amount, currDenom, out amount);
				if (numOfBills > 0)
					results.Add(currDenom, numOfBills);
			}

			// Uncomment the following and TestUnsolvableDenominationsTest will pass.
			if (amount != 0)
				throw new ArgumentException();

			return results;
		}

		public static int DivRem(int dividend, int divisor, out int remainder)
		{
			int quotient = dividend / divisor;
			remainder = dividend % divisor;
			return quotient;

		}
	}
}

