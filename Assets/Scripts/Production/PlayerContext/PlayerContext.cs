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
        PlayerComponentContainer components;
        private void Start()
        {
            transitionTo(new Standing(this));
        }

        class PlayerComponentContainer
        {
            public Transform transform;
            public Rigidbody2D rigidbody2D;
        }
        public override void Update()
        {
            currState.HandleUpdate();
        }

        public override void FixedUpdate()
        {
            currState.HandleFixedUpdate();
        }

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

        protected class PlayerStateKey : StateKey
        {
            public static PlayerStateKey
                Standing = new PlayerStateKey(0),
                Walking = new PlayerStateKey(1),
                InAir = new PlayerStateKey(2);
            public PlayerStateKey(int val) : base(val) { }


        }

    }

}