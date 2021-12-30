using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


[TestFixture]
public class TestJumper
{
    // A Test behaves as an ordinary method
    GameObject player;
    Vector2 expectedPosition; 

    [SetUp]
    private void setUpJumpAtOrigin()
    {
        player.AddComponent<PlayerContext>();
        Vector3 startPos = new Vector3(0, 0, 0);
        player.transform.position = startPos;
        Time.timeScale = 2.0f; 
    }

    [TearDown]
    private void tearDownJumpAtOrigin() 
    {  

    }

    [UnityTest]
    public IEnumerable jumpAtOrigin()
    {
        
        yield return 0f;
    }

}
