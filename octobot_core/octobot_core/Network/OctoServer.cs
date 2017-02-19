using octobot_core.Logging;
using octobot_core.network.protocol;
using octobot_core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network
{
 public class OctoServer
    {
        public bool isActiveConnection { get; set; }

        private IPAddress ipAdress;
        private TcpListener listenerList;
        private MessageDispatcher messageHandler;
        private Log log;
        private bool isRunning = true;
       
        public OctoServer(ServerConfiguration configuration)
        {
            this.ipAdress = IPAddress.Parse("127.0.0.1");
            listenerList = new TcpListener(this.ipAdress, configuration.port);
            this.log = LogFactory.getInstance().createLog();
            this.messageHandler = new MessageDispatcher(this.log);
            this.isActiveConnection = false;
        
        }

        public void start()
        {
            listenerList.Start();
            this.log.Write(LogLevel.INFO, LogType.CONSOLE, "Server started at localhost:8001");
            this.listen();
        }
        private void listen()
        {
            Socket s = listenerList.AcceptSocket();
            isActiveConnection = true;
            processRequest(s);
        }

        private void  processRequest(Socket s)
        {
           byte[] m = new byte[1024];
       
            while (isRunning)
            {
               int  k = s.Receive(m);
                if (k != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < k; i++)
                    {
                        sb.Append(Convert.ToChar(m[i]));             
                    }
                    messageHandler.parseMessage(sb.ToString());
                }
            }
        }

        public void stop()
        {
            listenerList.Stop();
            this.isRunning = false;
            this.isActiveConnection = false;
        }
    }
}
