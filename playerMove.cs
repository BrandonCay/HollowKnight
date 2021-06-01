using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * BUG: Falls through floor at left side of map. Most likely due to jumping setting collisions to 0 without exiting the first collision; investigate larger spacing
 * BUG 5/31: My intiali hyp was correct, the solution is to make a ceiling check that catches that leaves space to jump high enough 
 * to trigger on exit. For a layerMask approach, the following applies.
 */
public class playerMove : MonoBehaviour
{
    [SerializeField] float rightVel = 0f, upVel = 0f, runSpeed = 6f, jmpH = 5f;
    const float GRAV_A = -6f;//gravity acceleration negative
    Vector2 movePos;
    const string rightK = "d", leftK = "a", upK = "w", jumpK = "space";//horizontal axis can be used for right and left
    int[] blocked = { 0,0,0,0}; //Tracks which sides are blocked; first element = top and moves clockwise; 0 == no collision; 0>  ==  some collisions
    enum Direction:int
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
    private void Update()
    {
        if (blocked[0]>0) //hit the ceiling
            upVel = 0f;
        if (blocked[2] == 0)
        {//in air
            upVel += GRAV_A * Time.deltaTime; //gravity
        }
        else if (Input.GetKeyDown(jumpK) && blocked[0] == 0) //onGround && press jump
        {
            upVel = Mathf.Sqrt(jmpH * -2f * GRAV_A);
            Debug.Log("JMP " + upVel.ToString());
            blocked[2] = 0;///zero 
        }
        else//onGround && didn't jump
            upVel = 0f;

        if (Input.GetKey(rightK) && blocked[1] ==0)
        {
            rightVel = runSpeed;
          //blocked[3]=0;//left is free if one can go right
        }
        else if (Input.GetKey(leftK) && blocked[3] ==0)
        {
            rightVel = -runSpeed;
        //    blocked[1]= 0; 
        }
        else
            rightVel = 0f;

        movePos = Vector2.right * rightVel + Vector2.up * upVel;
        transform.Translate(movePos * Time.deltaTime); 
    }
    public void setRvel(float v)
    {
        rightVel = v;
    }

    public float getRvel()
    {
        return rightVel;
    }
    public void setUvel(float v)
    {
        upVel = v;
    }
    public float getUvel()
    {
        return upVel;
    }

    public void setBlocked(int index, int val)
    {
        blocked[index] = val;
    }

    public int getBlocked(int index)
    {
        return blocked[index];
    }
}
