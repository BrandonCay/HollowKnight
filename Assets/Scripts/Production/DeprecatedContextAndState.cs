using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Production
{
    //PROBLEM: cannot initialize states with values from previous states. To accomplish, you need to use a constructor. To overcome getComponent overhead,
    //store in context OR store in state but only use GetComponent in start then continue to pass the state reference of a component to the next component
    /*
    class DeprecatedContextAndState
    {
abstract public class Context : MonoBehaviour
    {
        protected State[] allStates { get; set; }
        protected State currState;
        protected int[] instanceCountForEachState;

        abstract public void Update();
        abstract public void FixedUpdate();

        public void transitionTo(in StateKey key)
        {
            this.currState = allStates[key];
        }
        public void transitionTo(ref State currState)
        {
            this.currState = currState;
        }

        public void transitionTo(ref State currState, Context thisContext)
        {
            this.currState = currState;
            this.currState.set_currContext(thisContext);
        }

        public abstract class State
        {
            protected int maxInstanceCount = 1;
            abstract public void HandleUpdate();
            abstract public void HandleFixedUpdate();

            public void set_currContext(Context newContext)
            {
                throw new NotImplementedException();
            }
            protected void isThereTooManyInstances(int currInstanceCount)
            {
                if (currInstanceCount > maxInstanceCount)
                    throw new ArgumentException("Too many instances for this state");
            }

            public void set_properties()
            {
                throw new NotImplementedException();
            }

        }
        abstract public class StateKey//prevent public access to keys while allowing context to use keys
        {
            public int Value { get; private set; }
            public override string ToString()
            {
                return Value.ToString();
            }

            protected StateKey(int value)
            {
                this.Value = value;
            }

            public static implicit operator int(in StateKey value)
            {
                return value.Value;
            }

            /* deprecated: use transitionTo. Left just in case
            public static T insertStateKeyIntoArray<T>(in StateKey key, in T [] arr)//
            {
                int index = key, arrLength = arr.Length;
                if (index >= arrLength || index < 0 )
                    throw new IndexOutOfRangeException($"length of array = {arrLength}; index = {index}");

                return arr[index];
            }
            */


    /*
        }

    }



}
*/
}

/*

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
    private class Standing : PlayerState
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

    private class Walking : PlayerState
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

    private class InAir : PlayerState
    {

        private Rigidbody2D rb;
        private Jumper player;
        private Transform currPos;

        public InAir(PlayerContext currContext)
        {
            currPos = currContext.GetComponent<Transform>();
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
                    newPos = currPos + new Vector2(0, (1f * Time.fixedDeltaTime));
            rb.MovePosition(newPos);
        }

        public void set_properties(Jumper player)
        {

        }
    }

    protected class PlayerStateKey : StateKey
    {
        public static PlayerStateKey
            Standing = new PlayerStateKey(0),
            Walking = new PlayerStateKey(1),
            InAir = new PlayerStateKey(2);
        public PlayerStateKey(int val) : base(val) { }


    }

}
*/

