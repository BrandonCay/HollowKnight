using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    float maxHeight, acceleration;

    public Jumper()
    {
        maxHeight = 2f;
        acceleration = -9.81f;
    }

    public Jumper(int maxHeight, float acceleration)
    {
        this.maxHeight = maxHeight;
        this.acceleration = acceleration; 
    }

    public float calcInitialVelocityToJump()
    {
        return (Mathf.Sqrt(maxHeight * -2f * acceleration));
    }

}
