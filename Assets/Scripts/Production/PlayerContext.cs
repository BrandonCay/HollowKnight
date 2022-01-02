using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerContext : Context
{   
    //hide member but keep open to access to nested
    private void Start()
    {
        const int numberOfStates = 10;
        allStates = new State[numberOfStates];
        set_allStates();
        transitionTo(ref allStates[PlayerStateKey.Standing]);
    }

    private void set_allStates()
    {
        allStates[PlayerStateKey.Standing] = new Standing(this);
        allStates[PlayerStateKey.Walking] = new Walking(this);
        allStates[PlayerStateKey.InAir] = new InAir(this);
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

        public void Jump()
        {
            currContext.transitionTo(PlayerStateKey.InAir);
            currContext.currState.
        }
        public override void HandleFixedUpdate()
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

