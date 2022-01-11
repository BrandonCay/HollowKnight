using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class PlayerConstants
        {
            private readonly static float xWalkSpeed = 1f;

            public static float get_xWalkSpeed()
            {
                return xWalkSpeed;
            }
        }

    }
}
