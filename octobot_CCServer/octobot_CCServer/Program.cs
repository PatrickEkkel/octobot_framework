using octobot_core.Logging;
using octobot_core.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace octobot_CCServer
{
    class Program
    {
        public static object Log { get; private set; }

        static void Main(string[] args)
        {
            OctoServerManager octoServermanager = new OctoServerManager(8000);
            octoServermanager.SpawnDefaultServer();

            Console.ReadLine();
        }
    }
}
