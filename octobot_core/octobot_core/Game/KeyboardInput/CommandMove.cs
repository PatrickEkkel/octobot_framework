using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interceptor;

namespace octobot_core.Game.KeyboardInput
{
    class CommandMove:Move
    {
        public override void execute(Input input)
        {
            // press all keys in sequence
            foreach (var keypress in keys)
            {
                input.SendKey(keypress.Key, KeyState.Down);
                wait(keypress.Value);
            }

            // release all keys
            foreach (var keypress in keys)
            {
                input.SendKey(keypress.Key, KeyState.Up);
                wait();

            }
        }
    }
}
