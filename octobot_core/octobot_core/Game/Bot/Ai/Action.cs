using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.Bot.Ai
{
    class Action
    {
        private SituationType actionType { get; set; }
        
            

        public  bool doAction(SituationType currentSituation)
        {
            bool result = false;
            if(actionType == currentSituation)
            {


            }
            return result;

        }

    }
}
