using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerContextNameSpace
{
    public partial class PlayerContext : Context
    {
        //hide member but keep open to access to nested
        private PlayerComponentContainer components;
        private void Start()
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
        private partial class PlayerComponentContainer { }
        protected abstract partial class PlayerState { }
        protected partial class Standing 
        {
            protected abstract partial class PlayerCommand  { }
            protected partial class NoCommand { }
            protected partial class JumpCommand  { }

        }
        protected partial class Walking {
            protected partial class JumpCommand { }
        }

        protected partial class InAir { }
    }
}