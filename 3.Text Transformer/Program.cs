using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Text_Transformer
{
    using System.Runtime.Remoting.Messaging;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();
            string input = Console.ReadLine();
            while (input!= "burp")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            string inputString = sb.ToString();
            string pattern = @"([$%&'])([^$%&']+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matchs = regex.Matches(inputString);

            foreach (var match in matchs)
            {
                string matchString = match.ToString().Substring(1,match.ToString().Length-2);
                switch (match.ToString()[0])
                {
                    case '$':
                        {
                            int charInt;
                            for (int i = 0; i < matchString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    charInt = matchString[i]+1;
                                    result.Append((char)charInt);

                                }
                                else
                                {
                                    charInt = matchString[i] - 1;
                                    result.Append((char)charInt);
                                }

                                
                            }
                            result.Append(' ');
                        }
                        break;
                    case '%':
                        {
                            int charInt;
                            for (int i = 0; i < matchString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    charInt = matchString[i] + 2;
                                    result.Append((char)charInt);

                                }
                                else
                                {
                                    charInt = matchString[i] - 2;
                                    result.Append((char)charInt);
                                }


                            }
                            result.Append(' ');
                        }
                        break;
                    case '&':
                        {
                            int charInt;
                            for (int i = 0; i < matchString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    charInt = matchString[i] + 3;
                                    result.Append((char)charInt);

                                }
                                else
                                {
                                    charInt = matchString[i] - 3;
                                    result.Append((char)charInt);
                                }


                            }
                            result.Append(' ');
                        }
                        break;
                    case '\'':
                        {
                            int charInt;
                            for (int i = 0; i < matchString.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    charInt = matchString[i] + 4;
                                    result.Append((char)charInt);

                                }
                                else
                                {
                                    charInt = matchString[i] - 4;
                                    result.Append((char)charInt);
                                }


                            }
                            result.Append(' ');
                        }
                        break;
                }
            }


            Console.WriteLine(result.ToString());
        }

        
    }
}
