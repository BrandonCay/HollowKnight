using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

class TestDashRight: PlayerSetup
{
    float timeToExpectedVal, expectedXpos, tolerance;

    [SetUp]
    public void setUpTestDashRight() 
    {
        setUpPlayer();
        timeToExpectedVal = 1f;
        expectedXpos = 1f;
        tolerance = 0.05f;
    }
    [UnityTest]
    public IEnumerator execute()
    {
        yield return 1f;
        Assert.AreEqual(expectedXpos, 0f);
    }
    
    [TearDown]
    public void tearDownTestDashRight()
    {
        tearDownPlayer();
    }

}

