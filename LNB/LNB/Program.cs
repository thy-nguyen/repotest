using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNB
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] denom = { 500, 100, 50, 10, 5, 2, 1, 1000 };
			int amount = 2348;
			List<int> results = lnb(denom, amount);
			Console.WriteLine("Array line: "+ string.Join(",", results.ToArray()));
		}

		public static List<int> lnb(int[] arr, int b)
		{
			int[] sortedDenom = arr.OrderByDescending(i => (int) i).ToArray();

			List<int> result = new List<int>();

			//int[] result;
			int newAmount = b;

			for (int i = 0; i < arr.Length; i++)
			{
				int count = newAmount / sortedDenom[i];
				newAmount = newAmount % sortedDenom[i];

				if (count >= 0)
				{
					result.Add(count);
					result.Add(sortedDenom[i]);
				}
			}

			return result;
		}
	}
}
