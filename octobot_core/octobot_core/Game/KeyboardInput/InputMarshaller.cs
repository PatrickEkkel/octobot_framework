using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interceptor;
using System.Threading.Tasks;

namespace octobot_core.Game.KeyboardInput
{
   public class InputMarshaller
    {
        private Input interceptor { get; set; }
        public void loadInterceptor()
        {
            this.interceptor = new Input();
            this.interceptor.KeyboardFilterMode = KeyboardFilterMode.All;
            this.interceptor.Load();
        }
        private void wait()
        {
            System.Threading.Thread.Sleep(200);
        }
        public void executeMove(Move move)
        {
            move.execute(interceptor);
            wait();
        }
    }
}
