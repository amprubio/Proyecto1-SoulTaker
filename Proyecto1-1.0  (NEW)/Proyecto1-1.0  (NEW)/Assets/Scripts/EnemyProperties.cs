using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour {

    public float health;
    public float currentHealth;
    public float souls;
    public float darkness;
    private Ataque playerDamage;

	// Use this for initialization
	void Start ()
    {
        SetInitialReferences();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            ApplyDamage();
            Debug.Log(currentHealth);
        }
    }


    void SetInitialReferences()
    {
        if (GameObject.Find("Sword") != null)
        playerDamage = GameObject.Find("Sword").GetComponent<Ataque>();

        currentHealth = health;
    }

    void ApplyDamage()
    {
        if (playerDamage.DañoAtaque > 0)
        {
            currentHealth -= playerDamage.DañoAtaque;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(this.gameObject);
            }
        }
    }
}
