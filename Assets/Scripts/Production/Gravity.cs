using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
        public static class Gravity
        {
            private static float accelerationDueTogravity = -9.81f;
            public static float get_accelerationDueTogravity()
            {
            return accelerationDueTogravity;
            }
        }
}
