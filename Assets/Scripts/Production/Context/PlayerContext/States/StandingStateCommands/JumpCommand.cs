using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class Standing  {
            partial class JumpCommand : PlayerCommand
            {
                //how does base class call Standing s when the transition upcastng the parameter: new Standing() ? 
                public JumpCommand(Standing s) : base(s) { }
                override public void execute()
                {
                    Jumper player = new Jumper();
                    const float jumpDistance = 1f;
                    currState.currContext.transitionTo(new InAir(currState.currContext, new Jumper(jumpDistance), 0f, player.calcInitialVelocityToJump()));
                }
            }
        }
    }

}
