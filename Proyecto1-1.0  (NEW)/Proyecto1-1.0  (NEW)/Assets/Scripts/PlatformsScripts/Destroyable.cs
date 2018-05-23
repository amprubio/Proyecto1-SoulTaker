using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    public float waitTime = 1.0f;
    public float respawnTime = 2.0f;
    private bool touched = false;
    private Collider2D col;
    private SpriteRenderer rend;
    private float resetWait;
    private float resetRespawn;



    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        resetWait = waitTime;
        resetRespawn = respawnTime;
    }

    private void Update()
    {
        if (touched)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0f)
            {
                col.enabled = false;
                rend.enabled = false;
                waitTime = resetWait;
                touched = false;
                FindObjectOfType<AudioManager>().Play("Destroy");
            }
        }

        if (!col.isTrigger && !rend.enabled && !touched)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime < 0)
            {
                col.enabled = true;
                rend.enabled = true;
                respawnTime = resetRespawn;
                FindObjectOfType<AudioManager>().Play("Respawn");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touched = true;
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        touched = false;
    //    }
    //}

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(respawnTime);
    }
    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
