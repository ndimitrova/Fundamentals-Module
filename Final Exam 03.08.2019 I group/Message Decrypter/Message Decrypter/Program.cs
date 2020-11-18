using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^([$]|[%])(?<tag>[A-Z][a-z][a-z]+)\1[:] [[](?<first>[0-9]+)][|][[](?<second>[0-9]+)][|][[](?<third>[0-9]+)][|]$");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["tag"].Value}: {(char)int.Parse(match.Groups["first"].Value)}{(char)int.Parse(match.Groups["second"].Value)}{(char)int.Parse(match.Groups["third"].Value)}");
                }

                else
                {
                    Console.WriteLine($"Valid message not found!");
                }
            }
        }
    }
}
