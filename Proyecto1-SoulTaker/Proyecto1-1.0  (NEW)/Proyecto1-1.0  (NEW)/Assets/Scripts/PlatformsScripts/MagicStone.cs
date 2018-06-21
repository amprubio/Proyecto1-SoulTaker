using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStone : MonoBehaviour {

    private SpriteRenderer sprite;
    private float colorG=0;
    private BoxCollider2D col;
    public float souls;
    public float darkness;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        
	}
    private void Update()
    {
        if(sprite.color == new Color(1f, 1f, 1f, 1f))
        {
            col.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            colorG += 0.25f;
            sprite.color = new Color(1f, colorG, 1f, 1f);
            GameManager.instance.AddSouls(souls);
            GameManager.instance.AddDarkness(darkness);
        }
    }
}
