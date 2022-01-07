using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerContextNameSpace
{
    public internal partial class PlayerContext : Context
    {
        //hide member but keep open to access to nested
        private PlayerComponentContainer components;

        public void Start()
        {
            transitionTo(new Standing(this));
        }

        public override void Update()
        {
            currState.HandleUpdate();
        }

        public override void FixedUpdate()
        {
            currState.HandleFixedUpdate();
        }

        internal partial class PlayerComponentContainer { }
        protected internal abstract partial class PlayerState { }
        protected internal partial class Standing
        {
            protected internal abstract partial class PlayerCommand { }
            protected internal partial class NoCommand { }
            protected internal partial class JumpCommand  { }

        }
        protected internal partial class Walking {
            protected partial class JumpCommand { }
        }
        protected internal partial class InAir { }
    }
}