using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    public Collider2D SwordCol;
    public float DañoAtaque;
    public float tRetardo = 2;
    public MovementController attack;
    public AnimationClip attackAnim;

    private bool rdy = true;
    private bool Hit = false;
    private SpriteRenderer player;

     

	void Start ()
    {
        
        SwordCol.enabled = false;
        attack = GameObject.Find("Player").GetComponent<MovementController>();
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        
	}
	void FixedUpdate ()
    {
        if ((GameInputManager.GetKeyDown("AttackKey") && rdy) || (GameInputManager.XButton() && rdy))
        {
            StartCoroutine(AttackTime(tRetardo));
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && (collision.isTrigger == false) && !Hit)
        {
            EnemyLifeSystem enemy = collision.gameObject.GetComponent<EnemyLifeSystem>();
            enemy.LoseHealth(DañoAtaque);
            Debug.Log("Hit" + DañoAtaque);
            Hit = true;
            FindObjectOfType<AudioManager>().Play("EnemyDamage2");
        }
    }

    IEnumerator AttackTime(float time)
    {
        SwordCol.enabled = true;
        attack.anim.SetBool("Attack", true);
        FindObjectOfType<AudioManager>().Play("Attack1");
        yield return new WaitForSeconds(attackAnim.length);
        attack.anim.SetBool("Attack", false);
        rdy = false;
        SwordCol.enabled = false;
        Hit = false;
        yield return new WaitForSeconds(time);
        rdy = true;
    }
    
}
