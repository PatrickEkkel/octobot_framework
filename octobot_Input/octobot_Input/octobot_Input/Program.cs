using octobot_core.Game.KeyboardInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_Input
{
    class Program
    {
        static void Main(string[] args)
        {
            InputMarshaller marshaller = new InputMarshaller();
            marshaller.loadInterceptor();
            CommandConsole commandConsole = new CommandConsole();
            while (true)
            {
                commandConsole.readFromConsole();
               // marshaller.executeMove(MoveFactory.S_MP());
            //    System.Threading.Thread.Sleep(500);
               // marshaller.executeMove(MoveFactory.C_MK());
            }

        }
    }
}

