using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class PlayerContext : Context
{
    private void Start()
    {
        transitionTo(new Standing(GetComponent<Transform>().position));
    }
    
    override public void Update()
    {
        currState.HandleUpdate();
    }

    public override void FixedUpdate()
    {
        currState.HandleFixedUpdate();
    }

    
    public class Standing: State
    {
        Vector2 pos;
        public Standing(Vector2 newPos)
        {
            pos = newPos;
        }
        public override void HandleUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"pos: {pos.ToString()}");
                Jump();
                Rigidbody2D rb = currContext.GetComponent<Rigidbody2D>();
                currContext.transitionTo(new InAir(pos, rb));
            }
        }

        private void Jump()
        {
            Jumper player;
        }
        public override void HandleFixedUpdate()
        {

        }

    }

    public class Walking: State
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

    public class InAir: State
    {
        
        private Vector2 currPos;
        private Rigidbody2D rb;
        private Jumper player;

        public InAir(Vector2 pos , Rigidbody2D rb)
        {
            this.currPos = pos;
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
    
}
