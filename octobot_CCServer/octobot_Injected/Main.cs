using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHook;

namespace octobot_Injected
{
    public class Main:IEntryPoint
    {
        public Main(RemoteHooking.IContext inContext, string inChannelName)
        {
            try
            {
               // Communication.Interface = RemoteHooking.IpcConnectClient<SF5Interface>(inChannelName);
               // Communication.Interface.WriteConsole("Dll successfully injected!");
            }
            catch (Exception ex)
            {
               // File.AppendAllText(Path.Combine(Path.GetTempPath(), "FTVInjectionLog.log"), ex.ToString());
                //RollbarUtility.SendError((object)this, "Couldn't initialise injection (Constructor)", ex);
            }
        }
    }
}
