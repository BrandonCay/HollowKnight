using UnityEngine;

namespace PlayerContextNameSpace {
    partial class PlayerContext
    {
        partial class Dashing
        {
            float xSpeed, xDirection, maxXdistance, originalXPosition;
            Transform transform;
            Rigidbody2D rb; 
            public Dashing(PlayerContext currContext,float xWalkSpeed, float xDirection)
            {
                set_currContext(currContext);
                float dashSpeedFactor = 3f;
                xSpeed = xWalkSpeed * dashSpeedFactor;
                this.xDirection = xDirection;
                maxXdistance = 3f;
                transform = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
                originalXPosition = transform.position.x;
            }

            public override void HandleUpdate()
            {
                if(originalXPosition - transform.position.x > maxXdistance)
                {
                    //switch to Standing if on ground or swithc to InAir if inair
                }
            }
            public override void HandleFixedUpdate()
            {
                float xVel = xSpeed * xDirection;
                Vector3
                    oldPos = transform.position,
                    displacement = new Vector3(xVel * Time.fixedDeltaTime, 0f, 0f),
                    newPos = oldPos + displacement;
                rb.MovePosition(newPos);
            }
            
        }
    }
}
