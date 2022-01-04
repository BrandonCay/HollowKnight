using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerContext : Context
{
    //hide member but keep open to access to nested
    PlayerComponentContainer components; 
    private void Start()
    {
        transitionTo(new Standing());
    }

    class PlayerComponentContainer
    {
        public Transform transform;
        public Rigidbody2D rigidbody2D;
    }
    public override void Update()
    {
        currState.HandleUpdate();
    }

    public override void FixedUpdate()
    {
        currState.HandleFixedUpdate();
    }

    protected abstract class PlayerState: State
    {
        protected PlayerContext currContext;

        public void set_currContext(PlayerContext newContext)
        {
            currContext = newContext;
        }
    }

    protected class Standing: PlayerState
    {
        private Transform currPos;
        private Rigidbody2D rb;

        public Standing(PlayerContext context)
        {
            set_currContext(context);
            currPos = currContext.components.transform;
            rb = currContext.components.rigidbody2D;
        }


        public override void HandleUpdate()
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        protected abstract class PlayerCommand: Command
        {
            protected Standing currState;

            public PlayerCommand(Standing newState)
            {
                currState = newState;
            }

            abstract public void execute();
        }

        protected class NoCommand : PlayerCommand {
            public NoCommand(Standing newState) : base(newState) { }
            
        }
            

        protected class JumpCommand : PlayerCommand
        {
            JumpCommand(Standing s):base(s) { }            
            
            override public void execute()
            {
                Jumper player = new Jumper();
                currState.currContext.transitionTo(new InAir(currState.currContext, new Jumper(), 0f, player.calcInitialVelocityToJump()));
            }

        }
        public override void HandleFixedUpdate()
        {
            
        }        
        
    }

    protected class Walking: PlayerState
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

    protected class InAir: PlayerState
    {
        
        private Rigidbody2D rb;
        private Jumper player;
        private Transform currPos;
        private float currXvel, currYvel, gravityAcceleration;

        public InAir(PlayerContext currContext) {
            this.currContext = currContext;
            currPos = currContext.components.transform;
            rb = currContext.components.rigidbody2D;
            gravityAcceleration = -9.81f;
        }

        public InAir(PlayerContext currContext, Jumper player, float currXvel, float currYvel):this(currContext)
        {
            this.player = player;
            this.currXvel = currXvel;
            this.currYvel = currYvel;
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

