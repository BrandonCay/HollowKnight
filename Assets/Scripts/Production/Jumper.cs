using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    float maxHeight, acceleration;


    public Jumper()
    {
        maxHeight = 4f;
        acceleration = -9f;

    }

    public float calcInitialVelocityToJump()
    {
        return (Mathf.Sqrt(maxHeight * -2f * acceleration));
    }
}
