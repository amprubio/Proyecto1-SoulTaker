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

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Sword" && GameManager.instance.souls-amountSouls != 0 && GameManager.instance.darkness-amountDarkness != 0)
        {
			GameManager.instance.SubsSouls (amountSouls);
			GameManager.instance.SubsDarkness (amountDarkness);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.ChangeStats(gameObject.name);
    }
}
