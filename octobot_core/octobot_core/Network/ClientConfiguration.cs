using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Network
{

   public enum ClientMode { Standalone,Slave }

  public  class ClientConfiguration
    {
      public  int port { get; set; }
      public ClientMode mode { get; set; }
      public String name { get; set;  }
    }
}
