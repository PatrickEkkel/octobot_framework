using Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.KeyboardInput
{
  public  class Move
    {

        public Dictionary<Keys,int> keys { get; set; }
        
        public Move()
        {
            keys = new Dictionary<Keys, int>();
        }
        protected void wait()
        {
            System.Threading.Thread.Sleep(15);
        }
        protected void wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        public virtual void execute(Input input)
        {
   
        }
    }
}
