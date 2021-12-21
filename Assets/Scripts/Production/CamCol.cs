using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCol : MonoBehaviour
{
    /*
     BUG 6/9
    Not colliding
     */


    Dictionary<string, int> colliders = new Dictionary<string, int>();//
    //stores colliders that the camera is touching
    [SerializeField] Camera cam;
    CamMove cMove;
    void Awake()
    {
        cMove = GameObject.Find("Main Camera").GetComponent<CamMove>();
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        float cpX = collision.GetContact(0).point.x,  cX = transform.position.x;
        cX -= cpX;

        Debug.Log("COLLIDE: " + cX.ToString());
        
        if(cX > 0f)//left hit
        {
            CamMove.blocked[0] += 1;
            //greaterVal[origin to the right] - lesserVal[leftSide] = pos+ 
            colliders.Add(collision.collider.name, 0);
        }
        else
        {
            CamMove.blocked[1] += 1;
            // lesserVal[origin to the left] - greaterVal[rightSide]= neg-  therefore 
            colliders.Add(collision.collider.name, 1);

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
        string name = collision.collider.name;
        int index= colliders[name];
        colliders.Remove(name);
        CamMove.blocked[index] -= 1;//exited one collider at a side
    }



    void Update()
    {
        setScale();
    }

    void setScale()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 newls = new Vector3(width, height, 0);
        transform.localScale = newls;

    }
}
