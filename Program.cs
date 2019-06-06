namespace HackRanked
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the number of lines. (15 max)");
            var values = new string[Convert.ToInt32(Console.ReadLine())];

            Console.WriteLine("Inputs");

            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"{i+1}. ");
                values[i] = Console.ReadLine();
            }

            var result = braces(values);
            Console.WriteLine("Outputs");

            Console.WriteLine(string.Join("\n", result));
            Console.ReadLine();
        }

        private static string[] braces(string[] values)
        {
            var bracesResponse = new List<string>();
            for (int i = 0; i < values.Length; i++)
            {
                var brace = values[i];
                var braceLength = brace.Length;
                var minBranceLength = 1;
                var maxBranceLength = 100;

                if (braceLength >= 1 && braceLength <= 100)
                {
                    brace = BracketsValidationsAndReplace(brace);
                    AddYesOrNot(bracesResponse, brace);
                }
                else
                {
                    Console.WriteLine($"The line must have a length between {minBranceLength} and {maxBranceLength}. It's {brace.Length} verify on the position {i}");
                    break;
                }
            }
            return bracesResponse.ToArray();
        }

        private static string BracketsValidationsAndReplace(string brace)
        {
            var isBrackets = Regex.IsMatch(brace, @"^\[.*\]$");

            if (isBrackets)
            {
                brace = brace.Substring(1, brace.Length - 2);
            }

            return brace;
        }

        private static void AddYesOrNot(List<string> bracesResponse, string brace)
        {
            var matches = Regex.Matches(brace, @"(^\[)|((\[{1,1}\]|\{{1,1}\}|\({1,1}\))|^(\{)|(\})$)|\]$", RegexOptions.ExplicitCapture);

            var quotient = brace.Length / 2;

            if (quotient == matches.Count)
            {
                bracesResponse.Add("YES");
            }
            else
            {
                bracesResponse.Add("NO");
            }
        }
    }
}