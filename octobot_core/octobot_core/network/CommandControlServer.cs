using octobot_core.Logging;
using octobot_core.network.protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network
{
 public class CommandControlServer
    {
        private IPAddress ipAdress;
        private TcpListener listenerList;
        private MessageHandler messageHandler;

        private Log log;
        public CommandControlServer()
        {
            this.ipAdress = IPAddress.Parse("127.0.0.1");
            listenerList = new TcpListener(this.ipAdress, 8001);
            LogFactory logfactory = new LogFactory();
            this.messageHandler = new MessageHandler();
            this.log = logfactory.createLog();
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
            processRequest(s);
        }

        private void  processRequest(Socket s)
        {
           byte[] m = new byte[1024];
       
            while (true)
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
                    //log.Write(LogLevel.INFO, LogType.CONSOLE, sb.ToString());
                }
            }
        }

        public void stop()
        {
            listenerList.Stop();

        }
    }
}
