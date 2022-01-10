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

        public void Start()
        {
            setComponents();
            transitionTo(new Standing(this));
        }

        protected internal void setComponents()
        {
            components = new PlayerComponentContainer();
            components.transform = GetComponent<Transform>();
            components.rigidbody2D = GetComponent<Rigidbody2D>();
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
        protected internal abstract partial class PlayerState : State { }
        protected internal partial class Standing : PlayerState
        {
            protected internal abstract partial class PlayerCommand : Command  { }
            protected internal partial class NoCommand : PlayerCommand { }
            protected internal partial class JumpCommand : PlayerCommand { }
            protected internal partial class WalkCommand : PlayerCommand { }
            protected internal partial class DashCommand : PlayerCommand { }

        }
        protected internal partial class Walking : PlayerState
        {
            protected partial class JumpCommand  { }
        }
        protected internal partial class InAir : PlayerState { }
        protected internal partial class Dashing : PlayerState { }

        protected internal partial class Directions { }
    }
}