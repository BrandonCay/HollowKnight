using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerContextNameSpace
{
    partial class PlayerContext { 
        partial class Standing
        {
            partial class PlayerCommand : Command
            {
                protected Standing currState;

                public PlayerCommand(Standing newState)
                {
                    currState = newState;
                }

                abstract public void execute();
            }


        }
    }
}
