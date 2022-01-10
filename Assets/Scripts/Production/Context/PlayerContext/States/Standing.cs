using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace PlayerContextNameSpace
{
    partial class PlayerContext 
    {
        partial class Standing
        {
            private Transform currPos;
            private Rigidbody2D rb;

            public Standing(PlayerContext context)
            {
                set_currContext(context);
                currContext = context;
                currPos = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
                commandToExecute = new NoCommand(this);
            }


            public override void HandleUpdate()
            {
                commandToExecute.execute();

                if (Input.GetKeyDown(Keys.Jump))
                {
                    commandToExecute = new JumpCommand(this);
                } else if (Input.GetKeyDown(Keys.WalkLeft)) {
                    commandToExecute = new WalkCommand(this, PlayerContext.Directions.Left);
                } else if (Input.GetKeyDown(Keys.WalkRight))
                {
                    commandToExecute = new WalkCommand(this, PlayerContext.Directions.Right);
                }
                 else if (commandToExecute is NoCommand)
                {
                    
                }
                else
                {
                    commandToExecute = new NoCommand(this);
                }

            }

            public override void HandleFixedUpdate()
            {
            }

            protected static class Keys
            {
                static public KeyCode
                    Jump = KeyCode.Space,
                    WalkLeft = KeyCode.A,
                    WalkRight = KeyCode.D,
                    LookDown = KeyCode.S,
                    LookUp = KeyCode.W,
                    Dash = KeyCode.LeftShift,
                    AttackLeft = KeyCode.LeftArrow,
                    AttackRight = KeyCode.RightArrow,
                    AttackUp = KeyCode.UpArrow,
                    AttackDown = KeyCode.DownArrow,
                    QuickCast = KeyCode.LeftControl,
                    Focus = KeyCode.Q;
            }


        }
    }
}