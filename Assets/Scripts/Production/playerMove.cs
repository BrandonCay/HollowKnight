using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * BUG: Falls through floor at left side of map. Most likely due to jumping setting collisions to 0 without exiting the first collision; investigate larger spacing
 * BUG 5/31: My intiali hyp was correct, the solution is to make a ceiling check that catches that leaves space to jump high enough 
 * to trigger on exit. For a layerMask approach, the following applies.
 * 6/1 repalce with onCollision. Used FixedUpdate to move. colider will have contact point. Other objects MAY respond physically if need be
 *6/11 need to allow if(conditions) after state is set to change values withinState. Glide should be removed
 *Need to fix Walking bug where player can't switch directions because there's no IF check at the beggingng
 *to check direction every loop. The rule of thumb for states is 
 *each needs to have unique decisions && unique functions(s)/operations. If not, then not state
 *isActionInit functions are supposed to check to see if an action occurred
 *while keeping in mind the current state (current state presummes some 
 *conditions to avoid unnecessary 
 *computations such as Stanindg means 
 *colliding with ground therefore don't check for that 
 *
 *
 *Hindsight 6/12: Each State should have a class and isStateInit should be divided into methods
 *-Lesson: if grouping functions by a common name (i.e. belonging relationship), try classses 
 */
public class playerMove : MonoBehaviour
{
    /*
    [SerializeField] float jmpH = 1f, xVel, yVel;//deafult values overriden by serializeField;
    const float walkSpeed = 10f;

    int xDir { set; get; } = 0; int yDir { set; get; } = 0;
    Vector2 movePos;
    Rigidbody2D rb;
    const string rightK = "d", leftK = "a", upK = "w", jumpK = "space";//horizontal axis can be used for right and left
    int[] blocked = { 0, 0, 0, 0 };     //Tracks which sides are blocked; first element = top and moves clockwise; 0 == no collision; 0>  ==  some collisions
    static int cType = 0;
    const float xInAirSpeed = 10f;
    const float GRAV_A = -9f;//gravity acceleration negative
    bool ceilingHit = false;
    InAir ia;

    public enum MovementState
    {
        Nothing,
        Standing,
        Walking,
        InAir,
        WallSlide,
        Knockback,
    }

    MovementState ms;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ia = new InAir(this);
    }

    private void Update()
    {
        StateUpdate();
    }
    private void FixedUpdate()
    {

        movePos = new Vector2(xVel, yVel) * Time.fixedDeltaTime;
        if (blocked[2] == 0)//nothing blocking bottom, therefore fall
        {
        }

        Vector2 pPos = transform.position;//turn to 2D
        rb.MovePosition(pPos + movePos);
    }


    public void setBlocked(int index, int val)
    {
        blocked[index] = val;
    }

    public int getBlocked(int index)
    {
        return blocked[index];
    }


    private void StateFixed()
    {
        switch (ms)
        {
            case MovementState.Standing:
                Standing();
                break;
            case MovementState.Walking:
                Walking();
                break;
            case MovementState.InAir:
                InAirFixed();
                break;
            case MovementState.Knockback:
                break;
            case MovementState.WallSlide:
                break;
            default:
                Debug.Log("Nothing");
                break;
        }
    }
    private void StateUpdate()
    {
        switch (ms)
        {
            case MovementState.Standing:
                Standing();
                break;
            case MovementState.Walking:
                Walking();
                break;
            case MovementState.InAir:
                InAir();
                break;
            case MovementState.Knockback:
                break;
            case MovementState.WallSlide:
                break;
            default:
                Debug.Log("Nothing");
                break;

        }

    }


    //InAir Logic
    public void InAirUpdate()
    {

    }


    private class InAir
    {
        playerMove pm;
        public InAir(playerMove pm) { this.pm = pm; }


        public void Update()
        {
            if (isStanding())
            {

            }
            else if (isWallSlidingRight())
            {
                pm.xDir = 1;
                calcAirVel();
            }
            else if (isWallSlidingLeft())
            {
                pm.xDir = 1;
            }
            else if (isMovingLeft())
            {
                startMovingLeft();
            }
            else if (isMovingRight())
            {
                startMovingRight();
            }
            else if (isCeilingHitOnce())//If we hit the ceiling stop upward motion. Continue falling normally (fixedUpdate)
                pm.yVel = 0f;
        }


        private bool isWalkingLeft()
        {
            if (pm.blocked[2] == 0 && pm.blocked[3] == 0 && Input.GetKey(leftK))
                return true;
            return false;
        }


        private void startWalkingLeft()
        {
            pm.xDir = -1;
            pm.xVel = pm.xDir * walkSpeed;
            pm.ms = MovementState.Walking;            
        }

        private bool isWalkingRight()
        {
            if (pm.blocked[2] == 0 && pm.blocked[1] == 0 && Input.GetKey(rightK))
                return true;
            return false;
        }

        private void startWalkingRight()
        {
            pm.xDir = 1;
            pm.xVel = pm.xDir * walkSpeed;
            pm.ms = MovementState.Walking;
        }


        private bool isCeilingHitOnce()
        {
            return pm.blocked[0] > 0 && !pm.ceilingHit;
        }

        private void startCeilingHitOnce()
        {
            pm.yVel = 0f; 
        }

        private bool isMovingLeft()
        {
            return pm.blocked[3] == 0 && Input.GetKeyDown(leftK);
        }

        private void startMovingLeft()
        {
            pm.xDir = 1;
            calcAirVel();
        }

        public bool isMovingRight()
        {
            return pm.blocked[1] == 0 && Input.GetKeyDown(rightK);
        }

        private void startMovingRight()
        {
            pm.xDir = -1;
            calcAirVel();
        }
        public bool isStanding()
        {
            return pm.blocked[2] == 0;
        }

        public void startStanding()
        {
            pm.xVel = 0f;
            pm.yVel = 0f;
        }

        public bool isWallSlidingLeft()
        {
            return pm.blocked[3] > 0 && Input.GetKey(leftK);
        }

        public bool isWallSlidingRight()
        {
            return pm.blocked[1] > 0 && Input.GetKey(rightK);
        }


        public void startWalking()
        {
            startStanding();//sameAsStanding(); kept for consistency
        }


        private void calcAirVel()
        {
            pm.xVel = xInAirSpeed * pm.xDir;
        }

    }


    private void InAirFixed()
    {
        yVel += GRAV_A * Time.fixedDeltaTime; //kinematic gravity
    }
    //WallSliding

    //Standing Logic



    private class Standing {
        playerMove pm;
        Standing(playerMove pm) { this.pm = pm; }


        private bool isWalkingLeft()
        {
            return Input.GetKey(leftK) && pm.blocked[3] == 0;
        }

        private void startWalkingLeft()
        {
            pm.xDir = -1;
            pm.setWalkXvel();
            pm.ms = MovementState.Walking;
        }


        private bool isWalkingRight()
        {
            return Input.GetKey(rightK) && pm.blocked[1] == 0;
        }


        private void startWalkingRight()
        {
            pm.xDir = 1;
            pm.setWalkXvel();
            pm.ms = MovementState.Walking;
        }

        private bool isInAirFalling()
        {
            return pm.blocked[2] == 0;
        }

        private void startInAirFalling()
        {
            pm.ms = MovementState.InAir;
            return; //exitCollisionWill subtract blocked; yVel should be set to zero already; therefore no init needed
            //besides state change; function kept for
            //consistency
        }

        private bool isInAirJumping()
        {
            return Input.GetKeyDown(jumpK) && !pm.ceilingHit;
        }

        private void startInAirJumping()
        {
            pm.yVel = Mathf.Sqrt(pm.jmpH * -2f * GRAV_A);
            pm.blocked[2] = 0;//zero to reset bottom collision to allow jmp
            pm.ms = MovementState.InAir;
        }
    }


    //keep all sharable functions/variables in outter class.
    private class Walking{
        playerMove pm; 
        Walking(playerMove pm) { this.pm = pm; }
        
        private bool isStanding()
        {
            bool isRightK = Input.GetKeyDown(rightK), isLeftK = Input.GetKeyDown(leftK);
            return (!isRightK && !isLeftK) || (pm.blocked[1] > 0 && pm.xVel > 0f) || (pm.blocked[3] > 0 && pm.xVel < 0f);
        }

        private void Standing()
        {
            
        }


        private bool isInAirJumping()
        {
            
        }

        private void startInAirJumping()
        { 
        
        }
    }
    */
    
}
