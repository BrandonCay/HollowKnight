using UnityEngine;
using System.Collections;

namespace PlayerContextNameSpace
{


    partial class PlayerContext
    {
    partial class Standing
    {
        partial class DashCommand
        {
            
            public DashCommand (Standing newState, int xDirection):base(newState)
            {
                
            }
            override public void execute()
            {
                    currState.currContext.transitionTo(new Dashing(currState.currContext, )); 
            }
                
        }

    }
    }

}
