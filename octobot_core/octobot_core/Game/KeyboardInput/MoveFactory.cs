using Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.KeyboardInput
{
   public class MoveFactory
    {


        public static Move C_MP()
        {
            Move result = new CommandMove();

            result.keys.Add(Keys.Down,40);
            result.keys.Add(Keys.H,20);
            return result;
        }
        public static Move C_HP()
        {
            Move result = new CommandMove();

            result.keys.Add(Keys.Down, 40);
            result.keys.Add(Keys.J, 20);
            return result;
        }
        public static Move S_MP()
        {
            Move result = new CommandMove();
            result.keys.Add(Keys.H, 250);
            return result;
        }
        public static Move C_MK()
        {
            Move result = new CommandMove();
            result.keys.Add(Keys.Down, 40);
            result.keys.Add(Keys.N, 20);

            return result;
        }

    }
}
