using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    public Collider2D SwordCol;
    public float DañoAtaque;
    public float tRetardo;
    public MovementController attack;

    public float x;
    private bool ColliderActivo = false;
    private bool Hit = false;
    

	void Start ()
    {
        
        SwordCol.enabled = false;
        x = tRetardo;
        attack = GameObject.Find("Player").GetComponent<MovementController>();
        
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

    public void ActivaCollider()
    {
        SwordCol.enabled = true;
        tRetardo -= Time.deltaTime;
        attack.anim.SetBool("Attack", true);
    }
    private void DesactivaCollider()
    {
        SwordCol.enabled = false;
        tRetardo = x;
        ColliderActivo = false;
        attack.anim.SetBool("Attack", false);
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
