using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour {


    Collider2D player;
    private Collider2D detect;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        detect = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(detect, player);
    }
	
}
