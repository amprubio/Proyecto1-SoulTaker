using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadronBehaviour : MonoBehaviour {
	private bool obtain;
	// Use this for initialization
	void Start () {

		obtain = GetComponent<ItemsObtain> ().obtained;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeStat ();
	}
	private void ChangeStat(){
		if (obtain) {
			GameManager.instance.Ladron ();
		}
	}
}
