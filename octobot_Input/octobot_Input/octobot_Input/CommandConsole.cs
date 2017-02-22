using octobot_core.Game;
using octobot_core.Game.KeyboardInput;
using octobot_core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_Input
{
    class CommandConsole
    {
        private char FOLLOW_UP = '>';
        private char LINK = '.';
        private InputMarshaller marshaller;
        private Log log;
        public CommandConsole()
        {
            this.marshaller = new InputMarshaller();
            this.marshaller.loadInterceptor();
            this.log = LogFactory.getInstance().createLog();
        }

        public void readFromConsole()
        {
          String commandString =  Console.ReadLine();
          String [] splittedCommands = commandString.Split(FOLLOW_UP);
            // Put some delay in so we have time to switch to SFV window
            System.Threading.Thread.Sleep(2000);

            foreach (String command in splittedCommands)
            {

                if (command.Contains("."))
                {
                    // Link For now we only support max 2 moves per link
                    String[] links = command.Split(LINK);
                    List<Move> moves = new List<Move>();
                    foreach (String commandLink in links)
                    {
                        moves.Add(TranslateCommand(commandLink));
                    }
                    Link link = new Link(moves[0], moves[1]);
                    this.marshaller.executeLink(link);
                }
                else
                {
                    this.marshaller.executeMove(TranslateCommand(command));
                }
            }

        }
        private Move TranslateCommand(String command)
        {
            Move result = null;
            switch (command.Trim())
            {
                case Moves.C_MP:
                    result = MoveFactory.C_MP();
                   // this.log.Write(LogLevel.TRACE, LogType.CONSOLE, "Crouching MP");
                   //   this.marshaller.executeMove(MoveFactory.C_MP());
                    break;
                case Moves.C_HP:
                    result = MoveFactory.C_HP();
                   // this.log.Write(LogLevel.TRACE, LogType.CONSOLE, "Crouching HP");
                   // this.marshaller.executeMove(MoveFactory.C_HP());
                    break;
                case Moves.C_MK:
                    result = MoveFactory.C_MK();
                    break;
                case Moves.S_MP:
                    result = MoveFactory.S_MP();
                    break;
            }

            return result;
        }
         
    }
}
