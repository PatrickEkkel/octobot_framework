using Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.KeyboardInput
{
  public  class Link
    {
        public Move a { get; set; }
        private Move b { get; set; }

        public Link(Move a,Move b)
        {
            this.a = a;
            this.b = b;
        }
        protected void wait()
        {
            System.Threading.Thread.Sleep(15);
        }
        protected void wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        public void execute(Input input)
        {
            foreach (var keypress in a.keys)
            {
                input.SendKey(keypress.Key, KeyState.Down);
                wait(keypress.Value);
            }
            // release all keys
            foreach (var keypress in a.keys)
            {
                input.SendKey(keypress.Key, KeyState.Up);
            }
            wait(120);
            foreach (var keypress in b.keys)
            {
                input.SendKey(keypress.Key, KeyState.Down);
                wait(keypress.Value);
            }
            foreach (var keypress in b.keys)
            {
                input.SendKey(keypress.Key, KeyState.Up);
            }
        }


    }
}
