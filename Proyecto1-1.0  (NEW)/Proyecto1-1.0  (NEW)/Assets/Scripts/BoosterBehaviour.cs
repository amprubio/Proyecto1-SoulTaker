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

    private void OnTriggerStay2D()
	{Debug.Log ("pum");
		if((collision.gameObject.tag == "Player") && ((GameManager.instance.souls-amountSouls) > 0) && ((GameManager.instance.darkness-amountDarkness) > 0))
        {
			
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
