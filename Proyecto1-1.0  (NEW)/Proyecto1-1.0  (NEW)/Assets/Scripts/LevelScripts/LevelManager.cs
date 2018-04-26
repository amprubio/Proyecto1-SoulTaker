using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private MovementController player;
    public static LevelManager instance;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<MovementController>();
	}

    //Call this method whenever u guys want to respawn player, no matter if u collide with Water or Spikes. Dont use it for player.health = 0, use load the scene u want indeed.

    public void RespawnPlayer()  
    {
        player.transform.position = currentCheckpoint.transform.position;
    }
}
