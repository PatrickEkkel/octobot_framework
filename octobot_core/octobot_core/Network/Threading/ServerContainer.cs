using octobot_core.Logging;
using octobot_core.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace octobot_core.Network.Threading
{
    class ServerContainer
    {

        private OctoServer server { get; set; }
        private Thread thread { get; set; }
        private ServerConfiguration configuration { get; set; }

        private Log log;
        public ServerContainer(ServerConfiguration serverConfiguration)
        {
            this.thread = new Thread(new ThreadStart(this.Run));
            this.configuration = serverConfiguration;
            this.server = new OctoServer(this.configuration);
            this.log = LogFactory.getInstance().createLog();
        }

        private void Run()
        {
            this.server.start();
        }

        public void startContainer()
        {
            thread.Start();
        }
        public void stopContainer()
        {
            // Active connections kunnen we sluiten op een veilige manier middels het flippen van een boolean
            if (this.server.isActiveConnection)
            {
                server.stop();
                if(thread.IsAlive)
                {
                    // fallback naar abort als het niet goedschiks wil
                    thread.Abort();
                }
            }
            // We gebruiken blocking sockets dus moeten we de thread killen middels Abort
            else
            {
                thread.Abort();
            }

         
               
        }
    }
}
