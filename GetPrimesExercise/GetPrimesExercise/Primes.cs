using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrimesExercise
{
    internal class Primes
    {
        public static bool IsPrime(int number)
        {
            if (number < 1)
                return false;
            int maxV, Index;
            maxV = number - 1;
            Index = 2;
            while (Index <= maxV)
            {
                int maxV2, Index2;
                maxV2 = maxV;
                Index2 = Index;
                while (Index2 <= maxV2)
                {
                    if (Index2 * Index == number)
                        return false;
                    Index2 += 1;
                }
                Index += 1;
            }
            return true;
        }
    }
}
