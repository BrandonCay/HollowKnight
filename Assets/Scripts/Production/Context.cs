using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



abstract public class Context: MonoBehaviour
{
    protected IState[] allStates;
    protected IState currState;
    protected int[] instanceCountForEachState;

    abstract public void Update();
    abstract public void FixedUpdate();

    public void transitionTo(ref IState currState)
    {
        this.currState = currState;
        this.currState.set_currContext(this);
    }


    public interface IState
    {
        public void HandleUpdate();
        public void HandleFixedUpdate();
        public void set_currContext(Context newContext);
    }
    protected abstract class State: IState
    {
        protected Context currContext;
        protected int maxInstanceCount = 1;
        abstract public void HandleUpdate();
        abstract public void HandleFixedUpdate();
        private void isThereTooManyInstances(int currInstanceCount)
        {
            if (currInstanceCount > maxInstanceCount)
                throw new ArgumentException("Too many instances for this state");
        }
        public void set_currContext(Context newContext)
        {
            currContext = newContext;
        }


    }
    abstract protected class StateKey
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

        public static implicit operator int (StateKey value)
        {
            return value.Value;
        }
    }

}


