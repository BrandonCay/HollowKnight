using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace PlayerContextNameSpace
{
    public partial class PlayerContext 
    {
        protected partial class Standing : PlayerState
        {
            private Transform currPos;
            private Rigidbody2D rb;

            public Standing(PlayerContext context)
            {
                set_currContext(context);
                currPos = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
            }


            public override void HandleUpdate()
            {
                commandToExecute.execute();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    commandToExecute = new JumpCommand(this);
                }
                else
                {
                    commandToExecute = new NoCommand(this);
                }

            }

            public override void HandleFixedUpdate()
            {
            }


        }
    }
}