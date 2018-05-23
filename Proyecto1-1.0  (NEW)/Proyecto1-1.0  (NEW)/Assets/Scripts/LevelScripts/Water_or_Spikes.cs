using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_or_Spikes : MonoBehaviour {

    //Attach this script to a Water or Spike Object
    private MovementController player;
    private LevelManager levelManager;
    public int dmg = 2;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovementController>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //StartCoroutine(player.Knockback(0.02f, 15,player.transform.position));
            levelManager.RespawnPlayer();
            GameManager.instance.UpdateHealth(GameManager.instance.health - dmg);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //StartCoroutine(player.Knockback(0.02f, 50, player.transform.position));
            levelManager.RespawnPlayer();
            GameManager.instance.UpdateHealth(GameManager.instance.health - dmg);
        }

    }
}
