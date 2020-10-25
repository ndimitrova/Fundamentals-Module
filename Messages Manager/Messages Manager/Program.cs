using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] receivedCommand = command.Split("=");
                string firstPartOfCommand = receivedCommand[0];

                if (firstPartOfCommand == "Add")
                {
                    string username = receivedCommand[1];
                    int sent = int.Parse(receivedCommand[2]);
                    int received = int.Parse(receivedCommand[3]);

                    if (!sentMessages.ContainsKey(username))
                    {
                        sentMessages.Add(username, sent);
                        receivedMessages.Add(username, received);
                    }
                }

                else if (firstPartOfCommand == "Message")
                {
                    string sender = receivedCommand[1];
                    string receiver = receivedCommand[2];

                    if (sentMessages.ContainsKey(sender) && sentMessages.ContainsKey(receiver))
                    {
                        sentMessages[sender]++;
                        receivedMessages[receiver]++;

                        if (sentMessages[sender] + receivedMessages[sender] >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            sentMessages.Remove(sender);
                            receivedMessages.Remove(sender);
                        }

                        if (receivedMessages[receiver] + sentMessages[receiver] >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            sentMessages.Remove(receiver);
                            receivedMessages.Remove(receiver);
                        }
                    }
                }

                else if (firstPartOfCommand == "Empty")
                {
                    string username = receivedCommand[1];

                    if (username == "All")
                    {
                        sentMessages.Clear();
                        receivedMessages.Clear();
                    }

                    else
                    {
                        if (sentMessages.ContainsKey(username))
                        {
                            sentMessages.Remove(username);
                            receivedMessages.Remove(username);
                        }
                    }
                }
            }

            Console.WriteLine($"Users count: {sentMessages.Count}");

            foreach (var kvp in receivedMessages.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                string user = kvp.Key;
                int receivedMessagesPerUser = kvp.Value;
                int sentMessagesPerUser = sentMessages[user];
                int sum = receivedMessagesPerUser + sentMessagesPerUser;

                Console.WriteLine($"{user} - {sum}");
            }
        }
    }
}
