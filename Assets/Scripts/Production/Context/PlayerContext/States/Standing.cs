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
                Debug.Log(context);
                set_currContext(context);
                Debug.Log($"set: {currContext}");
                currContext = context;
                Debug.Log($"assign: {currContext}");
                Debug.Log(currContext.components);
                Debug.Log(currContext.components.transform);
                currPos = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
                commandToExecute = new NoCommand(this);
            }


            public override void HandleUpdate()
            {
                commandToExecute.execute();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    commandToExecute = new JumpCommand(this);
                }else if(commandToExecute is NoCommand)
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


        }
    }
}