using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerContext : Context<PlayerContext>
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

    protected class Standing: State<Standing>
    {
        private Transform currPos;
        private Rigidbody2D rb;

        public Standing(PlayerContext context)
        {
            set_currContext(context);
            currPos = currContext.GetComponent<Transform>();
            rb = currContext.GetComponent<Rigidbody2D>();
        }


        public override void HandleUpdate()
        {
            Debug.Log($"State: {currPos.position.ToString()}");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        protected void Jump()
        {
        }

        protected class JumpCommand : Command<Standing>
        {
            JumpCommand(Standing s) : base(s) { }                
            override public void execute()
            {
                Jumper player = new Jumper();
                currState.currContext.inairState.set_properties(player, 0f, player.calcInitialVelocityToJump());
                currState.currContext.transitionTo(currState.currContext.inairState);
            }

        }
        public override void HandleFixedUpdate()
        {
            
        }

        public void set_properties()
        {
            
        }
        
        
    }

    protected class Walking: State
    {

        class JumpCommand
        {

        }
        private Vector2 pos;
        private Rigidbody2D rb;

        public Walking(PlayerContext currContext)
        {

        }
        public override void HandleUpdate()
        {
            
        }

        public override void HandleFixedUpdate()
        {

        }
    }

    protected class InAir: State
    {
        
        private Rigidbody2D rb;
        private Jumper player;
        private Transform currPos;
        private float currXvel, currYvel, gravityAcceleration;

        public InAir(PlayerContext currContext) {
            this.currContext = currContext; 
            currPos = currContext.GetComponent<Transform >();
            rb = currContext.GetComponent<Rigidbody2D>();
            gravityAcceleration = -9.81f;
        }

        public override void HandleUpdate()
        {

        }

        //need to create unittest
        public override void HandleFixedUpdate()
        {
            currYvel = currYvel + gravityAcceleration * Time.fixedDeltaTime;

            float currPosX = this.currPos.position.x , currPosY = this.currPos.position.y,
                nextPosX = currPosX + currXvel * Time.fixedDeltaTime , nextPosY = currPosY + currYvel * Time.fixedDeltaTime; 

            Vector2 positionAfterFrame =  new Vector2( nextPosX , nextPosY);

            rb.MovePosition(positionAfterFrame);
        }

        public void set_properties(Jumper player, float currXvel, float currYvel)
        {
            this.player = player;
            this.currXvel = currXvel;
            this.currYvel = currYvel;
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

