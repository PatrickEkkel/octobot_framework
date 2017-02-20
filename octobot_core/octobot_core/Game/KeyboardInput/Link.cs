using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.KeyboardInput
{
    class Link
    {
        public Move a { get; set; }
        private Move b { get; set; }

        public Link(Move a,Move b)
        {
            this.a = a;
            this.b = b;
        }

    }
}
