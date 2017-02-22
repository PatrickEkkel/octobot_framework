using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octobot_core.Game.Bot.Ai
{
    public enum SituationType { OnWakeUp,OnCornered,
        onBlockedLowLightMove,
        onBlockedHighLightMove ,
        onBlockedLowMediumMove,
        onBlockedHighMediumMove,
        onBlockedLowHardMove,
        onBlockedHighHardMove,
        onMatchStart,
        onFullScreen,
        onHalfScreen,
        onQuarterScreen
    }
}
