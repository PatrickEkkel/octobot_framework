using octobot_core.network.protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network
{
    class MessageFactory
    {

        public MessageFactory()
        {

        }

        public Message createSizeMessage(String message)
        {
            Message result = new Message();
            int valueLength = ProtocolCommands.MSG_SIZE_VALUE.Length;
            int intStringLength = Convert.ToString(message.Length).Length;

            StringBuilder sb = new StringBuilder();

            if (intStringLength != valueLength)
            {
                for (int i = 0; i < valueLength - intStringLength; i++)
                {
                    sb.Append("0");
                }
            }

            result.message = sb.ToString() + message.Length;
            result.type = ProtocolCommands.MSG_SIZE;
            
            return result;
        }

        public Message createMessage(String message,String type)
        {
            Message result = new Message();

            result.message = message;
            result.type = type;

            return result;
        }
    }
}
