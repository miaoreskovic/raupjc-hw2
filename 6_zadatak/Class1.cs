using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_zadatak
{
    public class Class1
    {
        static async Task<int> FactorialDigitSum(int n)
        {

            int sum = 1;
            for (int i = n; i >= 0; i--)
            {
                sum *= i;
            }
            return sum;
        }

        private static async void AsyncFunctionCall()
        {
            Task<int> returnedTaskResult = FactorialDigitSum(5);
            int sumResult = await returnedTaskResult;
            Console.WriteLine(sumResult);
        }

        static void Main(string[] args)
        {
            AsyncFunctionCall();
        }
    }
}
