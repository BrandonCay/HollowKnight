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

        partial class InAir : PlayerState
        {

            private Rigidbody2D rb;
            private Jumper player;
            private Transform currPos;
            private float currXvel, currYvel, gravityAcceleration;

            public InAir(PlayerContext currContext)
            {
                this.currContext = currContext;
                currPos = currContext.components.transform;
                rb = currContext.components.rigidbody2D;
                gravityAcceleration = -9.81f;
            }

            public InAir(PlayerContext currContext, Jumper player, float currXvel, float currYvel) : this(currContext)
            {
                this.player = player;
                this.currXvel = currXvel;
                this.currYvel = currYvel;
                gravityAcceleration = -9.81f;
            }

            public override void HandleUpdate()
            {

            }

            //need to create unittest
            public override void HandleFixedUpdate()
            {
                currYvel = currYvel + gravityAcceleration * Time.fixedDeltaTime;

                float currPosX = this.currPos.position.x, currPosY = this.currPos.position.y,
                    nextPosX = currPosX + currXvel * Time.fixedDeltaTime, nextPosY = currPosY + currYvel * Time.fixedDeltaTime;

                Vector2 positionAfterFrame = new Vector2(nextPosX, nextPosY);

                rb.MovePosition(positionAfterFrame);
            }

        }
    }

}