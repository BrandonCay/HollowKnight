using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Collections;
    

[TestFixture]
public class TestWalkRight: PlayerSetup
{
    Vector3 expectedVal;

    [SetUp]
    public void setUpWalkRight()
    {
        setUpPlayer();
        setUpEnv();
        expectedVal = new Vector3(1, 0, 0);
    }

    [UnityTest]
    public IEnumerator executeTest()
    {
        yield return 0f;
        Assert.AreEqual(expectedVal, player.transform.position);
    }

    [TearDown]
    public void tearDownWalkRight()
    {
        tearDownPlayer();
    }

}
