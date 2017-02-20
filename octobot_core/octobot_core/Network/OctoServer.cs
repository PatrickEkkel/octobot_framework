using octobot_core.Logging;
using octobot_core.network.protocol;
using octobot_core.Network;
using octobot_core.Network.Protocol.Handlers;
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
        ServerConfiguration ServerConfiguration;
        ClientConfiguration ClientConfiguration;
        OctoClient octoClient;
       
        public OctoServer(ServerConfiguration configuration)
        {
            this.ipAdress = IPAddress.Parse("127.0.0.1");
            this.ServerConfiguration = configuration;
            this.ClientConfiguration = new ClientConfiguration();
            this.ClientConfiguration.mode = ClientMode.Slave;
            listenerList = new TcpListener(this.ipAdress, configuration.port);
            this.log = LogFactory.getInstance().createLog();
            this.messageHandler = new MessageDispatcher(this.log);
            this.messageHandler.ClientPortRecieved += new MessageDispatcher.ClientServerPortRecievedEventHandler(OnClientPortRecieved);
            this.isActiveConnection = false;
        
        }


        public virtual void OnClientPortRecieved(object sender,ClientServerPortEventArgs args)
        {
            this.log.Write(LogLevel.TRACE, LogType.CONSOLE, "Handshake recieved from client, endpoint running on " + args.port);
            this.ClientConfiguration.port =  args.port;
            this.octoClient = new OctoClient(this.ClientConfiguration);
            this.octoClient.connect();
        }

        public void start()
        {   
            listenerList.Start();
            this.log.Write(LogLevel.INFO, LogType.CONSOLE, "Server started at localhost: " + ServerConfiguration.port);
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
            try
            {
                StringBuilder sb = new StringBuilder();

                while (isRunning)
                {   
                    int k = s.Receive(m);
                    if (k != 0)
                    {
                        
                        for (int i = 0; i < k; i++)
                        {
                            char c = Convert.ToChar(m[i]);
                            sb.Append(Convert.ToChar(m[i]));
                            if (c == ProtocolCommands.TERMINATION_CHAR)
                            {
                                messageHandler.parseMessage(sb.ToString());
                                sb = new StringBuilder();
                            }
                         
                            
                        }
                   
                    }
                }
            }
            catch (SocketException ex)
            {
                this.log.Write(LogLevel.ERROR, LogType.CONSOLE, "Exception: " + ex.Message);
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
