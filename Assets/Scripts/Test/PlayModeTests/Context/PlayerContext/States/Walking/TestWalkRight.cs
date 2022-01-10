using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Collections;
using PlayerContextNameSpace;
    

[TestFixture]
public class TestWalkRight: PlayerSetup
{
    Vector3 expectedVal;
    float expectedTimeToVal;
    float tolerance; 

    [SetUp]
    public void setUpWalkRight()
    {
        setUpPlayer();
        setUpEnv();
        expectedVal = new Vector3(1, 0, 0);
        expectedTimeToVal = 1f;
        tolerance = 0.05f;
    }

    [UnityTest]
    public IEnumerator executeTest()
    {
        playerController.transitionTo(new PlayerContext.Walking(playerController, PlayerContext.Directions.Right));
        yield return new WaitForSeconds(1f);
        Assert.AreEqual(expectedVal.x, player.transform.position.x, tolerance);
    }

    [TearDown]
    public void tearDownWalkRight()
    {
        tearDownPlayer();
    }

}
