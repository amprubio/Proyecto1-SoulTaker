using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona2paso : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
	
		if (GetComponent<EnemyLifeSystem> ().CurrentHealth == 0) {
			Destroy(this.gameObject,20*Time.deltaTime);
		}
	}
}
