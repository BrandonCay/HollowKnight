using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using PlayerContextNameSpace;
class TestDashRight: PlayerSetup
{
    float timeToExpectedVal, expectedXpos, tolerance;
    bool isDashingExpectedVal;

    [SetUp]
    public void setUpTestDashRight() 
    {
        setUpPlayer();
        timeToExpectedVal = 1f;
        expectedXpos = 3f;
        tolerance = 0.05f;
        isDashingExpectedVal = false;
    }
    [UnityTest]
    public IEnumerator execute()
    {
        playerController.transitionTo(new PlayerContext.Dashing(playerController, PlayerContext.PlayerConstants.get_xWalkSpeed(), PlayerContext.Directions.Right));
        yield return new WaitForSeconds(1f);
        float xPosAfterDash = player.transform.position.x;
        Assert.AreEqual(expectedXpos, xPosAfterDash, tolerance);
        yield return new WaitForSeconds(1f);
        bool isDashing = false;
        if(playerController.currState is PlayerContext.Dashing)
        {
            isDashing = true;
        }
        Assert.AreEqual(isDashingExpectedVal, isDashing); 
    }
    
    [TearDown]
    public void tearDownTestDashRight()
    {
        tearDownPlayer();
    }

}

