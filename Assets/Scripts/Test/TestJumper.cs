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

        player = GameObject.Instantiate(new GameObject());
        var rb = player.gameObject.AddComponent<Rigidbody2D>();
        playerController = player.gameObject.AddComponent<PlayerContext>();
        playerController = player.gameObject.GetComponent<PlayerContext>();
        SpriteRenderer sr = player.AddComponent<SpriteRenderer>();
        sr.color = Color.blue;
        var sprite = Resources.Load<Sprite>("Prefabs/SquareSprite");
        Debug.Log(sprite);
        sr.sprite = sprite;
        Debug.Log($"sprite:{sr.sprite}");
        rb.bodyType = RigidbodyType2D.Kinematic;

        Debug.Log( $"mat: {sr.material}");
        player.transform.localScale = new Vector3(5, 5, 0);

        /*
        player.transform.position = new Vector3(0, 0, 0);
        Debug.Log(playerController);
        playerController.setComponents();
        playerStanding = new PlayerContext.Standing(playerController);
        playerController.currState = playerStanding; 
        playerController.currState.set_command(new PlayerContext.Standing.JumpCommand(playerStanding));
        player.SetActive(true);*/
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
    public IEnumerator testPlayerContextJump()
    {

        Debug.Log(playerController.transform.position);


        playerStanding = new PlayerContext.Standing(playerController);
        playerController.currState.set_command(new PlayerContext.Standing.JumpCommand(playerStanding));
        playerController.currState.commandToExecute.execute();

        yield return new WaitForSeconds(1f);

        Debug.Log(playerController.transform.position);

        Assert.AreEqual(player.transform.position.y,  1f, 0.01);
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

