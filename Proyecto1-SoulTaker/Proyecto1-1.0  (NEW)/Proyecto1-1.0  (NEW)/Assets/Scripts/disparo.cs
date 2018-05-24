using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject bullet, player, boss;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		while (rb.velocity.x == 0) {
			Instantiate (bullet,transform.position,Quaternion.FromToRotation(boss.transform.position,player.transform.position));
		}
	}
}
