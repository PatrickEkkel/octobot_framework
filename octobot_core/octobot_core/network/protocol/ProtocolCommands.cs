using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network.protocol
{
  public  class ProtocolCommands
    {
        public const String MSG_SIZE = "MSG_SIZE";
        public static String SEPERATOR = ":";
        public static String MSG_SIZE_VALUE = "00000000";
        public const  String MSG_FREEMSG = "MMSG_FREEMSG";
        public static String MSG_HELLO = "HELLO";
        public static String MSG_BYE = "BYE";
    }
}
