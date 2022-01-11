using System;

namespace PlayerContextNameSpace {
    partial class PlayerContext
    {
        partial class Dashing
        {
            partial class PlayerCommand
            {

                protected Dashing currState;
                public PlayerCommand(Dashing currState)
                {
                    this.currState = currState;
                }

                public abstract void execute();

            }

        }
    }
}
