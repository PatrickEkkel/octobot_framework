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

namespace octobot_core.network
{
   public class CommandAndControlClient
    {
        private TcpClient tcpClient;
        private Log log;
        private MessageFactory messageFactory;

  
        public CommandAndControlClient()
        {
            this.tcpClient = new TcpClient();
            this.log = LogFactory.getInstance().createLog();
            this.messageFactory = new MessageFactory();
        }

        public void connect()
        {
            this.log.WriteConsole("Connecting to C&C server");
            tcpClient.Connect("127.0.0.1", 8001);
            this.log.WriteConsole("Successfully connected to C&C server");
            this.sendHello();
        }


        private void sendHello()
        {
            sendMessage(ProtocolCommands.MSG_HELLO);
        }

        private void sendMessage(String message)
        {
            Stream networkStream = tcpClient.GetStream();
            Message pre_msg = messageFactory.createSizeMessage(message);
            Message body_msg = messageFactory.createMessage(message, ProtocolCommands.MSG_FREEMSG);
           
            byte[] pre_msg_bytes = pre_msg.Prepare();
            byte[] body_msg_bytes = body_msg.Prepare();

            networkStream.Write(pre_msg_bytes,0,pre_msg_bytes.Length);
            networkStream.Write(body_msg_bytes, 0, body_msg_bytes.Length);   
        }
  
    }
}
