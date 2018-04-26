using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    public Collider2D SwordCol;
    public float DañoAtaque;
    public float tRetardo;

    public float x;
    private bool ColliderActivo = false;
    private bool Hit = false;
	public Animator anima;

	void Start ()
    {
		anima = GetComponent<MovementController> ().anim;
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
		anima.Play ("mc_atk");
        SwordCol.enabled = true;
        tRetardo -= Time.deltaTime;
       // Debug.Log(tRetardo);
        //Debug.Log("SwordCol.enabled = " + SwordCol.enabled);
    }
    private void DesactivaCollider()
    {
		anima.Play ("mc_iddle");
        SwordCol.enabled = false;
        tRetardo = x;
        ColliderActivo = false;
        Hit = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && (collision.isTrigger == false) && !Hit)
        {
            EnemyLifeSystem enemy = collision.gameObject.GetComponent<EnemyLifeSystem>();
            enemy.LoseHealth(DañoAtaque);
            Debug.Log("Hit" + DañoAtaque);
            Hit = true;
        }
    }

}
