using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_or_Spikes : MonoBehaviour {

    //Attach this script to a Water or Spike Object 

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            levelManager.RespawnPlayer();
    }
}
