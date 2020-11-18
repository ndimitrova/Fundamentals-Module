using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string manipulatedString = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] receivedCommand = command.Split();
                string firstPartOfCommand = receivedCommand[0];

                if (firstPartOfCommand == "Translate")
                {
                    string symbol = receivedCommand[1];
                    string replacement = receivedCommand[2];

                    manipulatedString = manipulatedString.Replace(symbol, replacement);

                    Console.WriteLine(manipulatedString);
                }

                else if (firstPartOfCommand == "Includes")
                {
                    string part = receivedCommand[1];

                    if (manipulatedString.Contains(part))
                    {
                        Console.WriteLine("True");
                    }

                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (firstPartOfCommand == "Start")
                {
                    string start = receivedCommand[1];
                    int index = manipulatedString.IndexOf(start);

                    if (index == 0)
                    {
                        Console.WriteLine("True");
                    }

                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (firstPartOfCommand == "Lowercase")
                {
                    manipulatedString = manipulatedString.ToLower();

                    Console.WriteLine(manipulatedString);
                }

                else if (firstPartOfCommand == "FindIndex")
                {
                    string symbol = receivedCommand[1];
                    int index = manipulatedString.LastIndexOf(symbol);

                    Console.WriteLine(index);
                }

                else if (firstPartOfCommand == "Remove")
                {
                    int startIndex = int.Parse(receivedCommand[1]);
                    int count = int.Parse(receivedCommand[2]);

                    manipulatedString = manipulatedString.Remove(startIndex, count);

                    Console.WriteLine(manipulatedString);
                }

                command = Console.ReadLine();
            }
        }
    }
}
