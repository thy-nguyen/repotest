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
            int[] denom = { 1000, 500, 100, 50, 10, 5, 2, 1 };
            int amount = 2348;
            Console.WriteLine("Array line: "+ string.Join(",", lnb(denom, amount).ToArray()));
            
        }

        public static List<int> lnb(int[] arr, int b)
        {
            int[] sortedDenom = arr.OrderByDescending(i => (int) i).ToArray();

            List<int> result = new List<int>();

            //int[] result;
            int newAmount = b;

            for (int i = 0; i < arr[i]; i++)
            {
                int count = newAmount / sortedDenom[i];
                newAmount = newAmount % sortedDenom[i];

                if (count >= 0)
                {
                    result.Add(count);
                    result.Add(arr[i]);

                }


            }
            return result;

        }
    }
}
