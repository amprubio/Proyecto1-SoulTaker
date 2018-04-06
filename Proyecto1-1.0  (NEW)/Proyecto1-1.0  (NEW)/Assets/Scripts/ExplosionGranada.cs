using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGranada : MonoBehaviour {
	public float time=5f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, time * Time.deltaTime);	
	}
}
