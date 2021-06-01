using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    [SerializeField] playerMove pm;
    [SerializeField] int index, collideCnt; 
    private void Awake()
    {
        pm = GameObject.Find("Player").GetComponent<playerMove>();
    }

    //need to rewrite with switch statement
    private void OnTriggerEnter2D(Collider2D other)
    {
        pm.setBlocked(index, pm.getBlocked(index) + 1 );
        Debug.Log("ENTER: " + index + " NAME: " + other.name + " CNT: " + pm.getBlocked(index).ToString());
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        collideCnt = pm.getBlocked(index);
        if(collideCnt > 0)
            pm.setBlocked(index,  collideCnt-1);
        Debug.Log("EXIT: " + index + " NAME: "+ other.name + " CNT: " + pm.getBlocked(index).ToString());

    }

}
