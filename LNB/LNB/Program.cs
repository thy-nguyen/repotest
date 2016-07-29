using System;

namespace LNB
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = 2348;
			var results = MoneyUtilities.DetermineLeastNumberOfBills(denom, amount);

			Console.WriteLine($"Original denominations: {string.Join(", ", denom)}");
			Console.WriteLine($"Original amount: {amount:N0}");
			Console.WriteLine();
			foreach (var key in results.Keys)
				Console.WriteLine($"{results[key]:N0}....{key:N0}'s");
		}
	}
}
