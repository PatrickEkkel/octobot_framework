using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Logging
{
   public class LogFactory
    {
        public Log createLog()
        {
            return new Logging.Log();
        }
    }
}
