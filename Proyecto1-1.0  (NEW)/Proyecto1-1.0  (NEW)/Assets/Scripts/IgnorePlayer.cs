using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour {
	public Collider2D player, detect, feet,sword;

	// Use this for initialization
	void Start () {
		player = GetComponent<Collider2D> ();
		detect = GetComponent<Collider2D> ();
		feet = GetComponent<Collider2D> ();
		}
	
	// Update is called once per frame
	void Update() {
		Physics2D.IgnoreCollision(detect,player);
		Physics2D.IgnoreCollision(detect,feet);
	}
}
