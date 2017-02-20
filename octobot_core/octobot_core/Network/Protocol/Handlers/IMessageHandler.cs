using octobot_core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.network.protocol
{
    interface IMessageHandler
    {
        void Handle(Log log,String Payload);
    }
}
