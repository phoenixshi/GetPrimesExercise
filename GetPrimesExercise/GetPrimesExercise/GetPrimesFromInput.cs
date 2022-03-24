using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrimesExercise
{
    internal class GetPrimesFromInput
    {
        static List<string> permArray = new List<string>();
        public static List<string> permute(String str,
                               int l, int r)
        {
            if (l == r)
            {
                permArray.Add(str);
            }

            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
            //Remove the duplicate values
            List<string> results = permArray.Distinct().ToList();
            return results;
        }

        /* Swap Characters at position 
           @param a string value @param 
           i position 1 @param j position 2 
           @return swapped string */
        public static String swap(String a,
                                int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        static List<string> result = new List<string>();

        public static List<string> GetPrimes(int n, int m, string inputNumber)
        {
            List<string> pickedNumbers = new List<string>();
            List<string> pickedPrimes = new List<string>();

            if (result.Count == 4)// to quit the Recursive Function
            {
                return result;
            }
            if (n == m)//check the last picked number
            {
                bool success = false;
                List<string> lastPickedNumberList = permute(inputNumber, 0, inputNumber.Length - 1); //permute the last number                                                                           //[[1,1,2],[2,1,2],[1,1,2]]
                permArray.Clear();

                for (int i = 0; i < lastPickedNumberList.Count; i++)
                {
                    if (Primes.IsPrime(Convert.ToInt32(lastPickedNumberList[i])) && !result.Contains(lastPickedNumberList[i]))
                    {
                        success = true;
                        result.Add(lastPickedNumberList[i]);
                        return result;
                    }
                }
                if (!success)
                {
                    result.RemoveRange(result.Count - 1, 1);//if not working, remove the last round result
                }
            }
            else
            {
                bool success = false;
                //C(12,3)
                for (var i = 0; i < Math.Pow(2, n); i++)
                {
                    var a = 0;
                    List<int> tmp = new List<int>();

                    for (int j = 0; j < n; j++)
                    {
                        if ((i >> j) % 2 != 0)
                        {
                            a++;
                            tmp.Add(j);
                        }
                    }
                    if (a == m)
                    {
                        string num1 = "";

                        List<char> ninputNumber = inputNumber.ToCharArray().ToList();

                        for (var p = 0; p < tmp.Count; p++)
                        {
                            num1 += inputNumber[tmp[p]];
                        }
                        //must remove the biggest index first to avoid shifting
                        foreach (int indice in tmp.OrderByDescending(v => v))
                        {
                            ninputNumber.RemoveAt(indice);
                        }//remove 3 picks from array then do the next round
                        if (!pickedNumbers.Contains(num1))
                        {
                            pickedNumbers.Add(num1);
                            List<string> nump1 = permute(num1, 0, num1.Length - 1); //permute first 3 pick
                            permArray.Clear();                                       

                            for (var np1 = 0; np1 < nump1.Count; np1++)
                            {
                                string nump1s = nump1[np1];
                                if (Primes.IsPrime(Convert.ToInt32(nump1s)))
                                {
                                    if (!pickedPrimes.Contains(nump1s) && !result.Contains(nump1s))
                                    {
                                        //151
                                        pickedPrimes.Add(nump1s);
                                        result.Add(nump1s);

                                        GetPrimes(String.Join("", ninputNumber).Length, 3, String.Join("", ninputNumber));
                                        if (result.Count == 4)// to quit the Recursive Function
                                        {
                                            return result;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                if (!success) {
                    if (result.Count == 1)
                    {
                        result.Clear();
                    }
                    else {
                        result.RemoveRange(result.Count - 1, 1);
                    }
                } }
            return result;
        }
    }
}

