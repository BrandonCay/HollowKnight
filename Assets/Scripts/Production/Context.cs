using System.Collections;
using System.Collections.Generic;
using UnityEngine;



abstract public class Context: MonoBehaviour
{
    protected State currState;

    abstract public void Update();
    abstract public void FixedUpdate();

    public void transitionTo(State currState)
    {
        this.currState = currState;
        this.currState.set_currContext(this);
    }

    public abstract class State
    {
        protected Context currContext;
        abstract public void HandleUpdate();
        abstract public void HandleFixedUpdate();
        public void set_currContext(Context newContext)
        {
            currContext = newContext;
            
        }
    }

    private interface ContextMembers 
    {
        
    }
}


