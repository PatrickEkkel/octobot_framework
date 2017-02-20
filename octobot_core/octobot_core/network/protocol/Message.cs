using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network.protocol
{
    class Message
    {
        public String message { get; set; }
        public String type { get; set; }
 
        public byte [] Prepare()
        {
            StringBuilder sb = new StringBuilder();
            int valueLength = ProtocolCommands.MSG_SIZE_VALUE.Length;
            String protocolmessage = type + ProtocolCommands.MSG_SEPERATOR + message + ProtocolCommands.TERMINATION_CHAR;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(protocolmessage.ToString());
            return ba;
        }
    }
}
