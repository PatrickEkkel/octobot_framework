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

        Log log;
        int minPortRange = 8001;
        int maxPortRange = 8010;
        int maxServer = 0;
        int actualPort = 0;
         

        public OctoServerManager()
        {
            this.serverContainers = new List<ServerContainer>();
            this.maxServer = maxPortRange - minPortRange;
            this.actualPort = minPortRange;
            this.log = LogFactory.getInstance().createLog();
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
