using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLand : MonoBehaviour {

	void OnCollisionStay2D(Collider2D cool) {
		SpriteRenderer currentenemy = cool.gameObject.GetComponent<SpriteRenderer> ();	
	if (cool.gameObject.CompareTag ("Flip")) {
			if (currentenemy.flipX==true) {
				currentenemy.flipX = false;
			} else
				currentenemy.flipX = true;
		}
	}
}
