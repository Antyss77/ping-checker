using System;
using System.Net.NetworkInformation;

class Program {
    static void Main(string[] args) {
        Ping pingSender = new Ping();

        string[] serverNames = {"google.com", "www.amazon.fr", "baidu.com", "www.spiegel.de", "yandex.ru"};
        string[] serverRegions = {"US", "FR", "CN", "DE", "RU"};

        for (int i = 0; i < serverNames.Length; i++)
        {
            string serverName = serverNames[i];
            string serverRegion = serverRegions[i];

            PingReply reply = pingSender.Send(serverName);

            if (reply.Status == IPStatus.Success)
            {
                int pingTime = (int) reply.RoundtripTime;
                string pingColor = Console.ForegroundColor.ToString();

                if (pingTime < 80)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (pingTime < 140)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"Server {serverRegion} : {pingTime} ms");

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"Unable to contact the server {serverRegion}");
            }
        }

        Console.Read();
    }
}