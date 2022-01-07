using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



abstract public class Context: MonoBehaviour
{
    protected internal State currState;

    abstract public void Update();
    abstract public void FixedUpdate();

    public void transitionTo(in State currState)
    {
        this.currState = currState;
    }

    public abstract class State
    {
        protected int maxInstanceCount = 1;

        protected internal Command commandToExecute; 
        public abstract void HandleUpdate();
        public abstract void HandleFixedUpdate();

        protected internal void set_command(Command nextCommand)
        {
            commandToExecute = nextCommand;
        }
        protected void isThereTooManyInstances(int currInstanceCount)
        {
            if (currInstanceCount > maxInstanceCount)
                throw new ArgumentException("Too many instances for this state");
        }

        protected internal interface Command
        {
            abstract public void execute();
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

        public static implicit operator int (in StateKey value)
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
    }

}
