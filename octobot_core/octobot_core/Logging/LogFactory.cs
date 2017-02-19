using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Logging
{
   public class LogFactory
    {

        private static LogFactory logFactory;

        private LogFactory()
        {

        }

        public static LogFactory getInstance()
        {
            if(logFactory == null)
            {
                logFactory = new LogFactory();
            }
            return logFactory;
        }

        public Log createLog()
        {
            return new Logging.Log();
        }
    }
}
