using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network.protocol
{
    enum ProcessState { WAITING,HDR_RECV }

    class MessageHandler
    {
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
            // Fighting Game commands 


            // Command and Control commands 

            // Other commands 

        }
    }
}
