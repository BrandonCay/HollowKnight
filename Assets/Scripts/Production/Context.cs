﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



abstract public class Context<ThisContext>: MonoBehaviour
{
    protected State currState;

    abstract public void Update();
    abstract public void FixedUpdate();

    public void transitionTo(in State currState)
    {
        this.currState = currState;
    }
    public abstract class State
    {
        protected ThisContext currContext;
        protected int maxInstanceCount = 1;
        abstract public void HandleUpdate();
        abstract public void HandleFixedUpdate();

        public void set_currContext(in ThisContext currContext)
        {
            this.currContext = currContext;  
        } 
        protected void isThereTooManyInstances(int currInstanceCount)
        {
            if (currInstanceCount > maxInstanceCount)
                throw new ArgumentException("Too many instances for this state");
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


