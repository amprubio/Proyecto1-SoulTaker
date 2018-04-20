using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehaviour : MonoBehaviour {

    public int amountDarkness;
    public int amountSouls;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.SubsDarkness(amountDarkness);
        GameManager.instance.SubsSouls(amountSouls);
    }
}
