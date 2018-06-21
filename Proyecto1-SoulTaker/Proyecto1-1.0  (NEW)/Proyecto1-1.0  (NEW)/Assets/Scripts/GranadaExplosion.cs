using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaExplosion : MonoBehaviour {
	public int DañoAtaque = 30;
	public float time = 2.7f;
		void Start () {
		Destroy (this.gameObject,time);
	}
	
	// Update is called once per frame
	private void OnTriggerStay2D (Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			EnemyLifeSystem enemy = collision.gameObject.GetComponent<EnemyLifeSystem> ();
			enemy.LoseHealth (DañoAtaque);
		}
	}
}