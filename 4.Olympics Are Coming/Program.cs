using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Olympics_Are_Coming
{
    using System.Text.RegularExpressions;

    class Program
    {
        private static Dictionary<string, Dictionary<string,int>> results; 
        
        static void Main(string[] args)
        {
            results = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "report")
                {
                    break;
                }

                string[] inputArray = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string country = inputArray[1].Trim();
                string name = inputArray[0].Trim();

                Regex regex = new Regex(@"\s+");
                name = regex.Replace(name, " ");
                country = regex.Replace(country, " ");
                if (!results.ContainsKey(country))
                {
                    results.Add(country,new Dictionary<string, int>());
                    results[country].Add(name,1);
                }
                else
                {
                    if (!results[country].ContainsKey(name))
                    {
                        results[country].Add(name,1);
                    }
                    else
                    {
                        results[country][name]++;
                    }
                }

            }

            var newResult = results.OrderByDescending(k => k.Value.Values.Sum());
            foreach (var result in newResult)
            {
                Console.WriteLine($"{result.Key} ({result.Value.Values.Count} participants): {result.Value.Values.Sum()} wins");
            }
            
        }
    }
}
