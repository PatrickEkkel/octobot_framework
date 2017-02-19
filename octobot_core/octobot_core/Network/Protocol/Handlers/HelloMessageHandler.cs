using octobot_core.Logging;
using octobot_core.network.protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Network.Protocol.Handlers
{
    class HelloMessageHandler : IMessageHandler
    {
        public void Handle(Log log)
        {
            log.WriteConsole("Hello eventhandler werkt blijkbaar");
        }
    }
}
