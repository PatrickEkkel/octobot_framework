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

           switch(header)
            {
                case ProtocolCommands.MSG_SIZE:
                    state = ProcessState.HDR_RECV;
                    break;
                case ProtocolCommands.MSG_FREEMSG:
                    handleGenericMessage(message_components[1]);
                    break;
            }
        }

       private void handleGenericMessage(String message)
        {
            IMessageHandler handler = null;
            if( this.messageHandlers.TryGetValue(message,out handler))
            { 
              handler.Handle(this.log);
            }
            else
            {
                this.log.Write(LogLevel.ERROR, LogType.CONSOLE, "No suitable handler was found for message: " + message);
            }
            // Fighting Game commands 
            
            // Command and Control commands 

            // Other commands 
        }
    }
}
