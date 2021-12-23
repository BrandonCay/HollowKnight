using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerJumpAtOrigin
{
    // A Test behaves as an ordinary method
    Vector2 expectedPlayerPos = new Vector2(0, 2);
    Vector2 givenPlayerPos = new Vector2(0, 0);

    private void setUp()
    {

    }
    [UnityTest]
    public IEnumerator JumpWithEnumeratorPasses()
    {

        
        yield return new WaitForSeconds(1f);
    }
    private void tearDown() { 
    }
}
