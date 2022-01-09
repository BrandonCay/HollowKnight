using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    float jumpDistance, acceleration;

    public Jumper()
    {
        jumpDistance = 1f;
        acceleration = Constants.Gravity.get_accelerationDueTogravity();
    }

    public Jumper(float jumpDistance)
    {
        this.jumpDistance = jumpDistance;
        this.acceleration = Constants.Gravity.get_accelerationDueTogravity();
    }

    public float calcInitialVelocityToJump()
    {
        return (Mathf.Sqrt(jumpDistance * -2f * acceleration));
    }

}
