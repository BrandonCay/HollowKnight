using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using PlayerContextNameSpace;

[TestFixture]
public class TestJumper
{
    Jumper player;
    float expectedVal;



    [SetUp]
    public void setUpTestJump()
    {
        player = new Jumper();
        expectedVal = 6.26f;
        
    }

    [TearDown]
    public void tearDownTestJump()
    {
        player = null;
        expectedVal = 0f;
    }

    [Test]
    public void testJump()
    {
        float initialVel = player.calcInitialVelocityToJump();
        Assert.AreEqual(expectedVal , initialVel, 0.01);
    }


}
