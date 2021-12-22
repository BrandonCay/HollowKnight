using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerContext : Context
{

    Transform testCurPos;
   
    private void Start()
    {
        const int numberOfStates = 10;
        allStates = new IState[numberOfStates];
        testCurPos = GetComponent<Transform>();
        Debug.Log($"{testCurPos.ToString()}");
        set_allStates();
        transitionTo(ref allStates[PlayerStateKey.Standing]);
    }

    private void set_allStates()
    {
        allStates[PlayerStateKey.Standing] = new Standing(this);
        allStates[PlayerStateKey.Walking] = new Walking(this);
        allStates[PlayerStateKey.InAir] = new InAir();
    } 
    
    public override void Update()
    {
        Debug.Log($"{testCurPos.ToString()}");
        currState.HandleUpdate();
    }

    public override void FixedUpdate()
    {
        currState.HandleFixedUpdate();
    }
    

    private class Standing: State
    {
        private Transform currPos;

        public Standing(Context currContext)
        {
            set_currContext(currContext);
            currPos = currContext.GetComponent<Transform>();
        }
        public override void HandleUpdate()
        {
            Debug.Log($"State: {currPos.ToString()}");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Jump()
        {
            /*
            Jumper player = new Jumper();
            Debug.Log($"pos: {curPos.ToString()}");
            Jump();
            Rigidbody2D rb = currContext.GetComponent<Rigidbody2D>();
            InAir s = currContext.inair;
            currContext.transitionTo();
            */

        }
        public override void HandleFixedUpdate()
        {

        }

    }

    private class Walking: State
    {
        private Vector2 pos;
        private Rigidbody2D rb;
        public override void HandleUpdate()
        {
            
        }

        public override void HandleFixedUpdate()
        {
        }
    }

    private class InAir: State
    {
        
        private Vector2 currPos;
        private Rigidbody2D rb;
        private Jumper player;

        public InAir()
        {

        }
        public InAir(Vector2 currPos , Rigidbody2D rb)
        {
            this.currPos = currPos;
            this.rb = rb;
            player = new Jumper();
        }
        public override void HandleUpdate()
        {
        }

        //need to create unittest
        public override void HandleFixedUpdate()
        {
            Vector2 newPos = currPos + new Vector2(0, (1f * Time.fixedDeltaTime));
            rb.MovePosition(newPos);
            currPos = newPos;
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
