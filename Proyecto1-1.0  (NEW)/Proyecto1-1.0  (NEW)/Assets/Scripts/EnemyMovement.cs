using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject enemyGraphic;
    bool canFlip = true;
	public bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
	public SpriteRenderer enemy;
    public float chargeTime;
    public float enemySpeed;
    float startChargeTime;
	public Animator anim;
    Rigidbody2D enemyRB;

    // Use this for initialization
    void Start()
    {
		/*StartCoroutine (Stop ());*/
        enemyRB = GetComponent<Rigidbody2D>();
    }
	/*IEnumerator Stop(){
	 
		if (enemyRB.velocity.x != 0) {
			anim.Play ("movement");
		}
		yield return null;
	}*/

    // Update is called once per frame
    void Update()
    {
        if (enemyRB.velocity.x == 0)
        {
            anim.SetBool("move", false);
        }

        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 2)
            {
                flipFacing();
            }
            int randomNumber = Random.Range(0, 10);
            if (randomNumber >= 2)
            {
                if (facingRight)
                {
					enemy.flipX = true;
                    enemyRB.velocity = new Vector2((enemySpeed - 2), 0f);
                    anim.SetBool("move", true);
                }
                else
                {
					enemy.flipX = false;
                    enemyRB.velocity = new Vector2((-enemySpeed + 2), 0f);
                    anim.SetBool("move", true);
                }
            }
            else
            {
				/*StopCoroutine (Stop ());*/
                enemyRB.velocity = new Vector2(0f, 0f);
            }
            nextFlipChance = Time.time + flipTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!(facingRight) && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;

            startChargeTime = Time.time + chargeTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                if (!facingRight)
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                    anim.SetBool("move", true);
                }
                else enemyRB.AddForce(new Vector2(+1, 0) * enemySpeed);
                anim.SetBool("move", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0f, 0f);
        }
    }

    void flipFacing()
    {
        if (!canFlip)
        {
            float facingX = enemyGraphic.transform.localScale.x;
            facingX *= -1f;
            enemy.flipX = !enemy.flipX;
            facingRight = !facingRight;
        }

    }
}