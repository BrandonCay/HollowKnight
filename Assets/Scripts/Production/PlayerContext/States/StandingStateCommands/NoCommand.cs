using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace {

    public partial class PlayerContext
    {
        partial class Standing
        {
            protected partial class NoCommand : PlayerCommand
            {
                public NoCommand(Standing newState) : base(newState) { }
                public override void execute()
                {

                }

            }
        }
    }
}
