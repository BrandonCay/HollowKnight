using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerContextNameSpace
{
    public partial class PlayerContext { 
        partial class Standing
        {
            protected abstract partial class PlayerCommand : Command
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
