using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using PlayerContextNameSpace;

[TestFixture]
public class TestJumper
{
    Jumper jPlayer;
    float expectedVal;
    GameObject player;
    PlayerContext playerController;
    const float customTimeScale = 2f;
    PlayerContext.Standing playerStanding;

    [SetUp]
    public void setUpTestJump()
    {
        setUpEnv();
        setUpPlayer();
        expectedVal = 6.26f;
    }

    private void setUpPlayer()
    {

        player = new GameObject("Player");
        player.AddComponent<Rigidbody2D>();
        player.AddComponent<Transform>();
        playerController = player.AddComponent<PlayerContext>();
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0, 0);
        playerStanding = new PlayerContext.Standing(playerController);
        playerController.currState.set_command(new PlayerContext.Standing.JumpCommand(playerStanding));
    }

    private void setUpEnv()
    {
        Time.timeScale = customTimeScale;

    }

    [TearDown]
    public void tearDownTestJump()
    {
        GameObject.Destroy(player);
        player = null;
        expectedVal = 0f;
    }

    [Test]
    public void testJump()
    {
        float initialVel = jPlayer.calcInitialVelocityToJump();
        Assert.AreEqual(expectedVal , initialVel, 0.01);
    }

    [UnityTest]
    public IEnumerable testPlayerContextJump()
    {


        playerController.currState.commandToExecute.execute();

        yield return new WaitForSeconds(3f);
    }

    class TestMemberContainers
    {
        public Test1Members test1members;
        public Test2Members test2members;
        public class Test1Members
        {

        }
        public class Test2Members
        {

        }
    }

}

