using System;
using System.Net.NetworkInformation;

class Program {
    static void Main(string[] args) {

        // Create a new Ping object to send ping requests
        Ping pingSender = new Ping();

        // Define the list of server names and regions to ping
        string[] serverNames = {"google.com", "www.amazon.fr", "baidu.com", "www.spiegel.de", "yandex.ru"};
        string[] serverRegions = {"US", "FR", "CN", "DE", "RU"};

        // Loop through each server and ping it
        for (int i = 0; i < serverNames.Length; i++)
        {
            // Get the name and region of the current server
            string serverName = serverNames[i];
            string serverRegion = serverRegions[i];

            // Send a ping request to the server and wait for the response
            PingReply reply = pingSender.Send(serverName);

            // If the ping request was successful, print the ping time and color it based on the value
            if (reply.Status == IPStatus.Success)
            {
                // Get the ping time in milliseconds
                int pingTime = (int) reply.RoundtripTime;

                // Get the current console text color
                string pingColor = Console.ForegroundColor.ToString();

                // Choose the color for the ping time based on its value
                if (pingTime < 80)
                {
                    Console.ForegroundColor = ConsoleColor.Green;  // green for fast ping times
                }
                else if (pingTime < 140)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;  // yellow for moderate ping times
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // red for slow ping times
                }

                // Print the server name, region, and ping time
                Console.WriteLine($"Server {serverRegion} : {pingTime} ms");

                // Reset the console text color to white
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                // If the ping request failed, print an error message
                Console.WriteLine($"Unable to contact the server {serverRegion}");
            }
        }

        // Wait for the user to press a key before closing the console window
        Console.Read();
    }
}
