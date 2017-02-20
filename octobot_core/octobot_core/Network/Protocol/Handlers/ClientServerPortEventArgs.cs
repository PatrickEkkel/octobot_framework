using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Network.Protocol.Handlers
{
  public  class ClientServerPortEventArgs: EventArgs
    {
      public  int port { get; set; }

    }
}
