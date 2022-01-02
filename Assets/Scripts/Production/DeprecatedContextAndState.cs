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
