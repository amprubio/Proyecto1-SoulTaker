using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    private LevelManager level;
    private Rigidbody2D player;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            player.isKinematic = true;
            level.ExitLevel();
            Debug.Log("Tengosueñito");
        }
    }

   
}
