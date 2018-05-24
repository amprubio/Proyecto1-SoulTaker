using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour {

    public float speed= 4;
    public Transform left;
    public Transform right;
    private int direction = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > right.position.x)
            direction = -1;
        else if (transform.position.x < left.position.x)
            direction = 1;

        transform.Translate(Vector3.right * direction * speed*Time.deltaTime);
	}
}
