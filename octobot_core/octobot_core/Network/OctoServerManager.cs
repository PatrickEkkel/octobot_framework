using octobot_core.Logging;
using octobot_core.Network.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Network
{
   public class OctoServerManager
    {

        List<ServerContainer> serverContainers;
        ServerContainer defaultServer;

        Log log;
        int minPortRange = 2;
        int maxPortRange = 10;
        int maxServer = 0;
        int actualPort = 0;
        int startingRange = 0;

        public OctoServerManager(int startingRange)
        {
            this.startingRange = startingRange;
            this.serverContainers = new List<ServerContainer>();
            // TODO: er zit niks wat checkt of de maxPortRange overschreden is ;-)
            this.maxServer = maxPortRange - minPortRange;
            this.actualPort = minPortRange + startingRange;
            this.log = LogFactory.getInstance().createLog();
        }


        public ServerConfiguration SpawnDefaultServer()
        {
            int port = startingRange + 1;
            ServerConfiguration result = new ServerConfiguration();
            result.port = port;
            this.defaultServer = new ServerContainer(result);
            this.log.Write(LogLevel.TRACE, LogType.CONSOLE, "Creating Default ServerContainer on port: " + port);
            defaultServer.startContainer();
            return result;
        }

        public ServerConfiguration SpawnServer()
        {
            ServerConfiguration result = new ServerConfiguration();
            result.port = actualPort;
            ServerContainer serverContainer = new ServerContainer(result);
            this.log.Write(LogLevel.TRACE, LogType.CONSOLE, "Creating ServerContainer on port: " + actualPort);
            serverContainer.startContainer();
            this.serverContainers.Add(serverContainer);
            actualPort++;
            return result;
        }
    }
}
