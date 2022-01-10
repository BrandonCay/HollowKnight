
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class Directions
        {
            public static Directions Left = new Directions("Left", -1);
            public static Directions Right = new Directions("Right", 1);
            public static Directions Up = new Directions("Up", 1);
            public static Directions Down = new Directions("Down", -1);
            public static Directions None = new Directions("None", 0);
            readonly string name;
            readonly int number;

            public Directions(string name = "None", int num = 0)
            {
                this.name = name;
                this.number = num;
            }

            public static implicit operator int(Directions currDir)
            {
                return currDir.number;
            }
            public override string ToString()
            {
                return name;
            }

        }
    }
}
