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
            String protocolmessage = type + ProtocolCommands.SEPERATOR + message;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(protocolmessage.ToString());
            // networkStream.Write(ba, 0, ba.Length);
            return ba;
        }
    }
}
