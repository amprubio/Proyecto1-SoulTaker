using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    public float chargeTime;
    public float enemySpeed;
    float startChargeTime;

    Rigidbody2D enemyRB;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
                    enemyRB.velocity = new Vector2((enemySpeed - 2), 0f);
                }
                else
                {
                    enemyRB.velocity = new Vector2((-enemySpeed + 2), 0f);
                }
            }
            else
            {
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
                }
                else enemyRB.AddForce(new Vector2(+1, 0) * enemySpeed);
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
        if (canFlip)
        {
            float facingX = enemyGraphic.transform.localScale.x;
            facingX *= -1f;
            enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
            facingRight = !facingRight;
        }

    }
}