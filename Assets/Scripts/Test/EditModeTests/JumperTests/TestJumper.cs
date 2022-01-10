using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class TestJumper
{

    float expectedVal;
    Jumper jPlayer;

    [SetUp]
    public void setUpJump()
    {
        expectedVal = 4.4f;
        jPlayer = new Jumper(1);
    }

    [TearDown]
    public void tearDownJump()
    {

    }

    [Test]
    public void testJump()
    {
        float initialVel = jPlayer.calcInitialVelocityToJump();
        Assert.AreEqual(expectedVal, initialVel, 0.1);
    }


}

