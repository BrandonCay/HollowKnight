using UnityEngine;
using System.Collections;

namespace PlayerContextNameSpace
{
    partial class PlayerContext
    {
        partial class Dashing
        {
            partial class NoCommand
            {
                int xDirection;
                float xSpeed;
                Rigidbody2D rb;
                Transform transform;
                public NoCommand(Dashing currState) : base(currState) {
                    xDirection = this.currState.xDirection;
                    xSpeed = this.currState.xSpeed;
                    transform = this.currState.transform;
                    rb = this.currState.rb;
                    
                }
                public override void execute()
                {

                    float xVel = xDirection * xSpeed, newXpositionAtNextFixedFrame = transform.position.x + xVel * Time.fixedDeltaTime;
                    Vector3 newPosition = transform.position + new Vector3(newXpositionAtNextFixedFrame, 0, 0);
                    rb.MovePosition(newPosition);
                }
            }

        }
    }
}
