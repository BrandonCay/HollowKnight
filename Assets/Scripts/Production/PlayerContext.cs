using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerContext : Context
{
    //hide member but keep open to access to nested
    private Standing standingState;
    private Walking walkingState;
    private InAir inairState; 
    private void Start()
    {
        set_allStates();
        transitionTo(standingState);
    }

    private void set_allStates()
    {
        standingState = new Standing(this);
        walkingState = new Walking(this);
        inairState = new InAir(this);
    }
    
    public override void Update()
    {
        currState.HandleUpdate();
    }

    public override void FixedUpdate()
    {
        currState.HandleFixedUpdate();
    }


    abstract private class PlayerState : State
    {
        protected PlayerContext currContext;

        protected void set_currContext(PlayerContext newContext)
        {
            currContext = newContext;
        }
    }
    private class Standing: PlayerState
    {
        private Transform currPos;

        public Standing(PlayerContext context)
        {
            set_currContext(context);
        }


        public override void HandleUpdate()
        {
            Debug.Log($"State: {currPos.position.ToString()}");
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Jump();
            }
        }

        private void Jump()
        {
            Jumper player = new Jumper();
            currContext.inairState.set_properties(player);
            currContext.transitionTo(currContext.inairState);  
        }
        public override void HandleFixedUpdate()
        {

        }

        public void set_properties()
        {
            
        }

    }

    private class Walking: PlayerState
    {
        private Vector2 pos;
        private Rigidbody2D rb;

        public Walking(Context currContext)
        {

        }
        public override void HandleUpdate()
        {
            
        }

        public override void HandleFixedUpdate()
        {
        }
    }

    private class InAir: PlayerState
    {
        
        private Rigidbody2D rb;
        private Jumper player;
        private Transform currPos;

        public InAir(PlayerContext currContext) {
            currPos = currContext.GetComponent<Transform > ();
            rb = currContext.GetComponent<Rigidbody2D>();
        }
        public override void HandleUpdate()
        {
        }

        //need to create unittest
        public override void HandleFixedUpdate()
        {
            Debug.Log($"State InAir: {this.currPos.position}");
            Vector2 currPos = this.currPos.position, 
                    newPos =  currPos + new Vector2(0, (1f * Time.fixedDeltaTime));
            rb.MovePosition(newPos);
        }

        public void set_properties(Jumper player)
        {

        }
    }

    protected class PlayerStateKey:StateKey
    {
        public static PlayerStateKey
            Standing = new PlayerStateKey(0),
            Walking = new PlayerStateKey(1),
            InAir = new PlayerStateKey(2);
        public PlayerStateKey(int val) : base(val) {}


    }
    
}

