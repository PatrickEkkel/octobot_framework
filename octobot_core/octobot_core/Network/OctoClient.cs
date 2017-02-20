using octobot_core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using octobot_core.network;
using octobot_core.network.protocol;
using System.IO;
using octobot_core.Network;

namespace octobot_core.network
{
   public class OctoClient
    {
        private TcpClient tcpClient;
        private Log log;
        private MessageFactory messageFactory;
        private OctoServerManager octoServerManager;
        private ClientConfiguration clientConfiguration;


        public OctoClient(ClientConfiguration clientConfiguration)
        {
            this.clientConfiguration = clientConfiguration;
            this.tcpClient = new TcpClient();
            this.log = LogFactory.getInstance().createLog();
            this.messageFactory = new MessageFactory();
            this.octoServerManager = new OctoServerManager(9000);
            this.GenerateName();
        }

        private void GenerateName()
        {
            // TODO: should consider making this global for an instance
            // Generate a random name for this client 
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            this.clientConfiguration.name = GuidString;

            this.log.Write(LogLevel.DEBUG, LogType.CONSOLE, "Name of this Client: " + this.clientConfiguration.name);
        }

        public void connect()
        {
         
            this.log.WriteConsole("Connecting to C&C server");
            tcpClient.Connect("127.0.0.1", this.clientConfiguration.port);
            this.log.WriteConsole("Successfully connected to C&C server");
            this.sendHello();
            if (clientConfiguration.mode == ClientMode.Standalone)
            {
                ServerConfiguration serverConfiguration = this.octoServerManager.SpawnDefaultServer();
                this.sendPortHandshake(serverConfiguration.port);
            }
        }

        private void sendHello()
        {
            sendMessage(ProtocolCommands.MSG_HELLO,this.clientConfiguration.name);
        }
        private void sendPortHandshake(int port)
        {
            Stream networkStream = tcpClient.GetStream();
            Message pre_msg = messageFactory.createSizeMessage(Convert.ToString(port));
            Message body_msg = messageFactory.createMessage(Convert.ToString(port), ProtocolCommands.MSG_CLNTSOCKETPORT);

            byte[] pre_msg_bytes = pre_msg.Prepare();
            byte[] body_msg_bytes = body_msg.Prepare();

            networkStream.Write(pre_msg_bytes, 0, pre_msg_bytes.Length);
            networkStream.Write(body_msg_bytes, 0, body_msg_bytes.Length);
        }

   
        private void sendMessage(String message,String payload)
        {

            String appendedMessage = message;
            if(payload != null)
            {
                appendedMessage += ProtocolCommands.FREEMSG_SEPERATOR + payload;
            }
            Stream networkStream = tcpClient.GetStream();
            
            Message pre_msg = messageFactory.createSizeMessage(appendedMessage);
            Message body_msg = messageFactory.createMessage(appendedMessage, ProtocolCommands.MSG_FREEMSG);
           
            byte[] pre_msg_bytes = pre_msg.Prepare();
            byte[] body_msg_bytes = body_msg.Prepare();

            networkStream.Write(pre_msg_bytes,0,pre_msg_bytes.Length);
            networkStream.Write(body_msg_bytes, 0, body_msg_bytes.Length);   
        }
  
    }
}
