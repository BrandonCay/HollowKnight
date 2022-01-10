using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class Standing
        {
            partial class WalkCommand
            {
                int xDirection;
                public WalkCommand(Standing currState, int xDirection) : base(currState)
                {
                    this.currState = currState;
                    this.xDirection = xDirection;
                }
                override public void execute()
                {

                    this.currState.currContext.transitionTo(new Walking(this.currState.currContext, xDirection));
                }
            }
        }
    }
}
