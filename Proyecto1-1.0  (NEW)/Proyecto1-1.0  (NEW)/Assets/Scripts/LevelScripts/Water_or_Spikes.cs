using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_or_Spikes : MonoBehaviour {

    //Attach this script to a Water or Spike Object 

    Vida vidaPlayer;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        vidaPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            levelManager.RespawnPlayer();
            vidaPlayer.VidaActual = vidaPlayer.VidaActual - 1;
        }
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            levelManager.RespawnPlayer();
            vidaPlayer.VidaActual = vidaPlayer.VidaActual - 1;
        }
            
    }
}
