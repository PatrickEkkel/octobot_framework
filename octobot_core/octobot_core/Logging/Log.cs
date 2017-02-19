using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Logging
{
    public enum LogLevel { INFO,WARNING,ERROR };
    public enum LogType { CONSOLE,FILE };
   public  class Log
    {

        public void Write(LogLevel logLevel,LogType logType,String message)
        {

            if(logType == LogType.CONSOLE)
            {
                writeConsole(logLevel,message);
            }
            else if(logType == LogType.FILE)
            {
                writeFile(logLevel);
            }

        }
        public void WriteConsole(String message)
        {
            writeConsole(LogLevel.INFO, message);
        }

        private void writeConsole(LogLevel loglevel,String message)
        {
            switch(loglevel)
            {
                case LogLevel.INFO:
                    Console.WriteLine("[" + loglevel.ToString() + "]: "  + message);
                    break;
            }
        }
        private void writeFile(LogLevel loglevel)
        {

        }

    }
}
