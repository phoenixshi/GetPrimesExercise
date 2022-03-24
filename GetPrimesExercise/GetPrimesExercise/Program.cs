// See https://aka.ms/new-console-template for more information
using GetPrimesExercise;

string product = "";
if ((product = Console.ReadLine()) != null)
{
    if (product.Length != 12 || product != String.Join("", product.ToCharArray().ToList().OrderBy(x => x)))// check if the product is in ascending order
    {
        Console.WriteLine("The input product is not valid , please check and enter a valid one.");
    }
    else
    {
        List<string> result = GetPrimesFromInput.GetPrimes(product.Length, 3, product);
        Console.WriteLine("The 4 primes are: ");
        result.ForEach(x => Console.WriteLine(x));
    }
    Console.ReadLine();
}
else
    Console.WriteLine("Please enter a valid product .");



