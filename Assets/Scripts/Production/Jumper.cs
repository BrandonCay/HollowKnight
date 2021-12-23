using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper
{
    float maxHeight, acceleration;


    public Jumper()
    {

    }

    public float calcInitialVelocityToJump()
    {
        return (Mathf.Sqrt(maxHeight * -2f * acceleration));
    }
}
