using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using PlayerContextNameSpace;


abstract public class PlayerSetup
{
    protected GameObject player;
    protected PlayerContext playerController;
    protected const float customTimeScale = 4f;
    protected void setUpPlayer()
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

        Debug.Log($"mat: {sr.material}");
        player.transform.localScale = new Vector3(5, 5, 0);
    }

    protected void setUpEnv()
    {
        Time.timeScale = customTimeScale;
    }

    protected void tearDownPlayer()
    {
        GameObject.Destroy(player);
        player = null;
    }

}

