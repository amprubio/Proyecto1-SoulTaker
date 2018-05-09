using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehaviour : MonoBehaviour {

    public int amountDarkness;
    public int amountSouls;
	public Collider2D collision;   


	// Use this for initialization
	void Start () {

	}

    private void OnTriggerEnter2D()
    {
		if(collision.gameObject.tag == "Sword" && GameManager.instance.souls-amountSouls >= 0 && GameManager.instance.darkness-amountDarkness >= 0)
        {
			Debug.Log ("pum");
			GameManager.instance.SubsSouls (amountSouls);
			GameManager.instance.SubsDarkness (amountDarkness);
            Destroy(gameObject);
		
		}

    }

    private void OnDestroy()
    {
		GameManager.instance.ChangeStats(name);
    }
}
