using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace
{
    public partial class PlayerContext
    {
        partial class Standing  {
            partial class JumpCommand : PlayerCommand
            {
                public JumpCommand(Standing s) : base(s) { }

                override public void execute()
                {
                    Jumper player = new Jumper();
                    currState.currContext.transitionTo(new InAir(currState.currContext, new Jumper(), 0f, player.calcInitialVelocityToJump()));
                }

            }
        }

    }

}
