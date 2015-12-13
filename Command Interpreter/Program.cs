using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Interpreter
{
    class Program
    {
        static void Main()
        {
            List<string> allStrings =
             Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands = Console.ReadLine();

            while (commands!="end")
            {
                try
                {
                    ExecuteCommand(allStrings, commands.Split(' '));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                
                commands = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", allStrings)}]");
        }

        private static void ExecuteCommand(List<string> allStrings, string[] commands)
        {
            switch (commands[0])
            {
                case "reverse":
                    {
                        int start = int.Parse(commands[2]);
                        int count = int.Parse(commands[4]);
                        if (start == allStrings.Count)
                        {
                            throw new ArgumentException();
                        }
                        var newCollection = allStrings.Skip(start).Take(count).ToList();
                        string old;
                        for (int i = 0; i < newCollection.Count/2; i++)
                        {
                            old = newCollection[newCollection.Count - 1-i];
                            newCollection[newCollection.Count - 1 - i] = newCollection[i];
                            newCollection[i] = old;
                        }
                        if (count > 1)
                        {
                            allStrings.RemoveRange(start, count);
                            allStrings.InsertRange(start, newCollection);
                        }

//                        allStrings.Reverse(start, count);

//                        Console.WriteLine($"[{string.Join(", ",allStrings)}]");
                    }
                    break;
                case "sort":
                    {
                        int start = int.Parse(commands[2]);
                        int count = int.Parse(commands[4]);
                        if (start == allStrings.Count)
                        {
                            throw new ArgumentException();
                        }
                        var newCollection = allStrings.Skip(start).Take(count).ToList();
                        newCollection.Sort();
                        allStrings.RemoveRange(start, count);
                        allStrings.InsertRange(start, newCollection);

//                        allStrings.Sort(start,count,StringComparer.InvariantCulture);
//                        Console.WriteLine($"[{string.Join(", ", allStrings)}]");
                    }
                    break;
                case "rollLeft":
                    {
                        int numberOfRows = int.Parse(commands[1]) % allStrings.Count;

                        var elementsToMove = allStrings.Take(numberOfRows).ToArray();
                        allStrings.AddRange(elementsToMove);
                        allStrings.RemoveRange(0,numberOfRows);
//                        Console.WriteLine($"[{string.Join(", ", allStrings)}]");
                    }
                    break;
                case "rollRight":
                    {
                        int numberOfRows = int.Parse(commands[1]) % allStrings.Count;

                        var elementsToMove =
                            allStrings.Skip(allStrings.Count - numberOfRows).Take(numberOfRows).ToArray();

                        allStrings.InsertRange(0,elementsToMove);
                        allStrings.RemoveRange(allStrings.Count-numberOfRows,numberOfRows);
//                        Console.WriteLine($"[{string.Join(", ", allStrings)}]");

                    }
                    break;
                
            }
        }
    }
}
