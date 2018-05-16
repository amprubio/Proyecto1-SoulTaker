using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHabilityBeahaviour : MonoBehaviour {
	public bool bossmuerto1=false, bossmuerto2=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D cool)
	{
		if (cool.gameObject.CompareTag ("Player")) {
			switch (this.gameObject.name) {
			case "Granada(Clone)":
				bossmuerto1 = GetComponent<Boss1Behaviour> ().deadboss1;
				bossmuerto1 = true;
				break;
			case"Escudo(Clone)":
				bossmuerto2 = GetComponent<Boss2Behaviour> ().deadboss2;
				bossmuerto2 = true;
				break;
			}
			Destroy (this.gameObject);
		}
	}
}
