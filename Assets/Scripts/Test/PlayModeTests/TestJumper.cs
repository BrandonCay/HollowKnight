using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using PlayerContextNameSpace;

[TestFixture]
public class TestJumper: PlayerSetup
{
    float expectedVal;
    const float timeToToReachExpectedVal = .452f;
    const float tolerance = .05f;
    PlayerContext.Standing playerStanding;

    [SetUp]
    public void setUpTestJump()
    {
        Debug.Log($"runp1: {player} ");
        setUpEnv();
        setUpPlayer();
        expectedVal = 1f;
        Debug.Log($"runp2: {player} ");
    }

    [TearDown]
    public void tearDownTestJump()
    {
        tearDownPlayer();
        expectedVal = 0f;
    }



    [UnityTest]
    public IEnumerator testPlayerContextJump()
    {

        Debug.Log(playerController.transform.position);


        playerStanding = new PlayerContext.Standing(playerController);
        playerController.currState.set_command(new PlayerContext.Standing.JumpCommand(playerStanding));
        playerController.currState.commandToExecute.execute();

        yield return new WaitForSeconds(timeToToReachExpectedVal);

        Debug.Log(playerController.transform.position);

        Assert.AreEqual(expectedVal, player.transform.position.y , tolerance);
    }
}

