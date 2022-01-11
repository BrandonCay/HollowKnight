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

            int xDirection;
            public DashCommand (Standing newState, int xDirection):base(newState)
            {
                    this.xDirection = xDirection;
            }
            override public void execute()
            {
                    float xWalkSpeed = 1f;
                    currState.currContext.transitionTo(new Dashing(currState.currContext, xWalkSpeed, xDirection)); 
            }
                
        }

    }
    }

}
