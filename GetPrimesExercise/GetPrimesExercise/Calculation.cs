using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrimesExercise
{
    internal class Calculation
    {
        public static List<int> AllPrimesInScope { get; set; }
        public static String Product { get; set; }
        public Calculation(String product)
        {
            AllPrimesInScope = GetAllPrimesInScope(100, 1000);
            Product = product;
        }
        public List<int> GetAllPrimesInScope(int min, int max)
        {
            List<int> primes = new List<int>();
            for (int i = min; i < max; i++)
            {
                if (GetPrimesExercise.Primes.IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }


        public static void Select(int currentIndex, int remain, string currentSelect)
        {
            if (remain == 0)
            {
                Console.WriteLine(Calculation.Sort(currentSelect));
                if(Calculation.Sort(currentSelect) == Product)
                {
                    Console.WriteLine("This is the one");
                    return;
                }
                return;
            }

            if (AllPrimesInScope.Count - currentIndex < remain)
                return;

            Select(currentIndex + 1, remain - 1, currentSelect + AllPrimesInScope[currentIndex]);
            Select(currentIndex + 1, remain, currentSelect);

        }

        public static string Sort(string input)
        {
            char[] charArr = input.ToCharArray();
            return string.Join("", charArr.OrderBy(x=>x));
        }
    }
}
