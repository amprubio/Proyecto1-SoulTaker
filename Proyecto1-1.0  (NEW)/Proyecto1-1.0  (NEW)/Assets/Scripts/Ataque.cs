using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    public Collider2D SwordCol;

    public float tRetardo = 2;
    private float x;
    private bool ColliderActivo = false;
    public int DañoAtaque;

	void Start ()
    {
        
        SwordCol.enabled = false;
        x = tRetardo;
        
	}
	
	
	void Update ()
    {
        tRetardo -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ColliderActivo = true;
        }
        if (tRetardo > 0 && ColliderActivo)
        {
            ActivaCollider();
        }
        else
        {
            DesactivaCollider();
        }
    }

    private void ActivaCollider()
    {
        SwordCol.enabled = true;
        tRetardo -= Time.deltaTime;
       // Debug.Log(tRetardo);
        //Debug.Log("SwordCol.enabled = " + SwordCol.enabled);
    }
    private void DesactivaCollider()
    {
        SwordCol.enabled = false;
        tRetardo = x;
        ColliderActivo = false;
    }
   
}
