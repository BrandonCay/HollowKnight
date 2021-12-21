using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public int hit { get; set; } = 0;
    Transform player;
    Rigidbody2D rb;
    Vector3 newPos = new Vector3(0, 0, 0);//new camera position
    public static int[] blocked = { 0, 0 };//0=left, 1=right side collision
    [SerializeField] float z=-10, y=2;//y= units from player on y-axis (2-3) ;z=depth from player (-10) 
    // Start is called before the first frame update
    // Update is called once per frame
    /*Can't remove parent because it will stop in the air if I jump and hit a wall.
     * Camera can't be a child of player because I need to manually control.
     * Consider reomoving it as child through Unity or through code (SetParent)
     * 
     */
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        newPos.z = z; //z is constant
        newPos.x = player.position.x;
    }
    
    void FixedUpdate()
    {
        float pY = player.position.y, pX = player.position.x;
        if ((blocked[0] == 0 && pX < newPos.x) || (blocked[1] == 0 && pX > newPos.x)) 
            //if the camera is NOT blocked on the side the player is moving towards, then
            //move the camera to player's position; else, keep the same position (do nothing)
        {
            newPos.x = pX;
        }
        
        newPos.y = pY + y; 
        rb.MovePosition(newPos);
        //move to player's position or stay at old position if hit 
        //no delta time because the camera follows the player which moves
    //at delta time
    }
}
