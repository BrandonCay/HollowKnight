using UnityEngine;

namespace PlayerContextNameSpace {
    partial class PlayerContext
    {
        partial class Dashing
        {
            float xSpeed, maxXdistance, currDistanceTraveled;
            int xDirection;
            Transform transform;
            Rigidbody2D rb; 
            public Dashing(PlayerContext currContext,float xWalkSpeed, int xDirection)
            {
                set_currContext(currContext);
                float dashSpeedFactor = 3f;
                xSpeed = xWalkSpeed * dashSpeedFactor;
                this.xDirection = xDirection;
                maxXdistance = 3f;
                transform = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
                currDistanceTraveled = 0f;
                set_command(new NoCommand(this));
            }

            public override void HandleUpdate()
            {
                commandToExecute.execute();
                if(didPlayerTravelFullDashLength())
                {
                    if (isOnGround())
                        currContext.transitionTo(new Standing(this.currContext));

                }else if (isPlayerHittingAWall())
                {
                    if (!isOnGround())
                    {
                        //wall slide state
                    }
                }

            }

            private bool didPlayerTravelFullDashLength()
            {
                return currDistanceTraveled > maxXdistance;
            }

            private bool isOnGround()
            {
                return true;
            }
            private bool isPlayerHittingAWall()
            {
                return false;
            }
            public override void HandleFixedUpdate()
            {
                float xVel = xSpeed * xDirection, xDisplacement = xVel * Time.fixedDeltaTime;
               
                currDistanceTraveled = currDistanceTraveled +  Mathf.Abs(xDisplacement);
                
                Vector3
                    oldPos = transform.position,
                    displacement = new Vector3(xDisplacement, 0f, 0f),
                    newPos = oldPos + displacement;
                rb.MovePosition(newPos);
            }
            
        }
    }
}
