using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    /*
    Dictionary<string, int> colliders = new Dictionary<string, int>();//tracks colliders that the player is touching
    [SerializeField] playerMove pm;
    [SerializeField] int xIndex, yIndex, collideCnt;
    private int cType;
    Vector2 p2cDiff, lastP, firstP;
    enum cTypes //collisionTypes stored in a type array
    {
        solidWall=1,
        
    }
    private void Awake()
    {
        pm = GetComponent<playerMove>();//changed to 
    }
    /*
     * 6/5: Collision works. Haven't tested ceiling but I changed the code so that 0f vel wont happen.
     * This code is essentially a manual, physics-less sphereOverlap. Consider layermask for simplicity, now that I
     * had my fun with colliders. These computations coulde be a problem for many AI. Also look into simulating kinematic
     * movement with Physics engine to avoid programming these colliders. Also, raycasts? Need to examine.
     */
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //use layers, need to use compareTo for efficient equality. Can make a list     
       // collision.
       /*
        switch (collision.collider.)
        {
            case "sldwal":
            break;
                "s"
            case 
        }
       */
       /*
        firstP = collision.GetContact(0).point;
        lastP = collision.GetContact(collision.contactCount - 1).point;//Find dimension (up-down or left-right or both[corner])
        p2cDiff = transform.position;//transforms to V2

        p2cDiff = firstP - p2cDiff;//Find side 
        if (firstP.x == lastP.x)//== means it occurred on that side
        {
            if (p2cDiff.x > 0)
                xIndex = 1; //pos = right
            else
                xIndex = 3;//neg =  left
  
            pm.setBlocked(xIndex, pm.getBlocked(xIndex) + 1);
            colliders.Add(collision.collider.name, xIndex);

        }
        else if (firstP.y == lastP.y)//Technically, a corner could have be both BUT prioritize x-dimension for dictionary
        {
            if (p2cDiff.y > 0)
                yIndex = 0; //pos = up
            else
                yIndex = 2;//neg =  down

            pm.setBlocked(yIndex, pm.getBlocked(yIndex) + 1);
            colliders.Add(collision.collider.name, yIndex);

        }
        //store name, not whole object

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        string n = collision.collider.name;
        exitFun(colliders[n]);
        colliders.Remove(n);

    }
    
    private void exitFun(int index)
    {
        collideCnt = pm.getBlocked(index);
        if (collideCnt > 0) //necessary to prevent -1 numbers after jump resets to 0. Jump resets to 0 to allow jumping 
            pm.setBlocked(index, collideCnt - 1);
        Debug.Log("EXIT: " + index + " CNT: " + pm.getBlocked(index).ToString());


    }
    */

}
