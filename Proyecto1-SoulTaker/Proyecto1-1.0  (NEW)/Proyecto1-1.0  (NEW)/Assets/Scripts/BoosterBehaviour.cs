using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehaviour : MonoBehaviour {

    public int amountDarkness;
    public int amountSouls;
	public Collider2D collision;

    private float totalSouls;
    private float totalDarkness;
    private Vector3 tempPos = new Vector3();
    private float amplitude = 0.01f;
    private float frequency = 0.5f;


    // Use this for initialization
    void Start ()
    {
        totalDarkness = GameManager.instance.darkness;
        totalSouls = GameManager.instance.souls;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (collision.gameObject.tag == "Sword" )//&& (totalSouls - amountSouls) > 0 && (totalDarkness - amountDarkness) > 0) 
        {

            GameManager.instance.SubsSouls(amountSouls);
            GameManager.instance.SubsDarkness(amountDarkness);
            Destroy(gameObject);

        }
    }

    void Update()
    {
        
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        
    }

    private void OnDestroy()
    {
		GameManager.instance.ChangeStats(name);
    }
}
