using System;
using UnityEngine;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class Walking : PlayerState
        {

            private int xDirection;
            private float xSpeed; 
            public Walking(PlayerContext currContext, int direction) 
            {
                set_currContext(currContext);
                xSpeed = 1f;
                xDirection = direction; 
            }
            public override void HandleUpdate()
            {
                
            }

            public override void HandleFixedUpdate()
            {
                float xVel = xDirection * xSpeed,
                    newXpositionAtFixedFrame = currContext.components.transform.position.x + xVel * Time.fixedDeltaTime;
                Vector2 newPos = new Vector2(newXpositionAtFixedFrame, currContext.components.transform.position.y);
                currContext.components.rigidbody2D.MovePosition(newPos);
            }
        }

    }
}
