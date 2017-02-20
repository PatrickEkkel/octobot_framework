using octobot_core.Logging;
using octobot_core.Network.Protocol.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network.protocol
{
    enum ProcessState { WAITING,HDR_RECV }

    class MessageDispatcher
    {

        // A delegate type for hooking up change notifications.
        public delegate void ClientServerPortRecievedEventHandler(object sender, ClientServerPortEventArgs e);

        public event ClientServerPortRecievedEventHandler ClientPortRecieved;
        Log log;
        Dictionary<String, IMessageHandler> messageHandlers;
        public MessageDispatcher(Log log)
        {
            this.log = log;
            this.messageHandlers = new Dictionary<string, IMessageHandler>();
            this.RegisterMessageHandlers();
        }

        private void RegisterMessageHandlers()
        {
            this.messageHandlers.Add(ProtocolCommands.MSG_HELLO,new HelloMessageHandler());
        }


        private ProcessState state = ProcessState.WAITING;
        public void parseMessage(String message)
        {

           String [] message_components =   message.Split(':');
           String header =   message_components[0];
           // Strip the Terminator char of the message
           message_components[1] =  message_components[1].Replace("#", "");

           switch(header)
            {
                case ProtocolCommands.MSG_SIZE:
                    state = ProcessState.HDR_RECV;
                    log.Write(LogLevel.DEBUG, LogType.CONSOLE, "MSG_SIZE command recieved");
                    log.Write(LogLevel.DEBUG, LogType.CONSOLE, "MSG_SIZE value: " + message_components[1]);
                    break;
                case ProtocolCommands.MSG_FREEMSG:
                    handleGenericMessage(message_components[1]);
                    break;
                case ProtocolCommands.MSG_CLNTSOCKETPORT:
                    ClientPortRecieved(this, new ClientServerPortEventArgs() { port = Convert.ToInt32(message_components[1]) });
                    break;
                default:
                    log.Write(LogLevel.DEBUG, LogType.CONSOLE, "Unknown protocolCommand recieved: " + message);
                    break;
            }
        }

       private void handleGenericMessage(String message)
        {
            IMessageHandler handler = null;

            if (message != null)
            {
                String []  message_components =  message.Split(ProtocolCommands.FREEMSG_SEPERATOR);

                if (this.messageHandlers.TryGetValue(message_components[0], out handler))
                {
                    if(message_components.Length > 1)
                    {
                        handler.Handle(this.log, message_components[1]);
                    }
                    else
                    {
                        handler.Handle(this.log, String.Empty);
                    }
                }
                else
                {
                    this.log.Write(LogLevel.ERROR, LogType.CONSOLE, "No suitable handler was found for message: " + message);
                }
            }
            // Fighting Game commands 
            
            // Command and Control commands 

            // Other commands 
        }
    }
}
