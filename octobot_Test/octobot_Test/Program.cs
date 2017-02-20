using octobot_core.network;
using octobot_core.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace octobot_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientConfiguration configuration = new ClientConfiguration();
            configuration.mode = ClientMode.Standalone;
            configuration.port = 8001;

            OctoClient octoClient = new OctoClient(configuration);
            octoClient.connect();


            Console.Read();           
        }
    }
}
