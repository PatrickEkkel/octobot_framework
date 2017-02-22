using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.Bot
{
    public enum SFVChar {  RYU,KEN,ALEX}

    class Character
    {
        private SFVChar Type = SFVChar.RYU;
        public bool stamina { get; set; }
        public bool stun { get; set;  }
    }
}
