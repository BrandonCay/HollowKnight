using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerContextNameSpace { 
    public partial class PlayerContext
    {
        protected abstract partial class PlayerState: State
        {
            protected PlayerContext currContext;

            public void set_currContext(PlayerContext newContext)
            {
                currContext = newContext;
            }


        }
    }




}
