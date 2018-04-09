using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageHealthSystem : MonoBehaviour {

    public int maxHealth;
    public int damageBoss;
    [HideInInspector]
    public int currentHealth;
    

	
	void Start ()
    {
        if (damageBoss == 0) damageBoss = 4;	
	}

	void Update ()
    {
        if (damageBoss <= 0) Destroy(gameObject);	
	}
}
