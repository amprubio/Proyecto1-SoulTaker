using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public Transform target;
    public float attack1Range = 0.1f;
    public GameObject objectExplosion;
    GameObject explosion;
    bool activaExplosion = false;

    public void Update()
    {
        CheckBoom();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            ActivaExplosion();
            Boom();
        }

    }

    public void CheckBoom()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist < 0) dist = dist * -1;

        if (dist < attack1Range)
        {
            ActivaExplosion();
            Boom();
        }
    }

    public void Boom()
    {
        if (activaExplosion == true)
        {
            explosion = GameObject.Instantiate(objectExplosion);
            explosion.transform.position = transform.position;
            Destroy(gameObject);

        }else activaExplosion = false;

    }

    public void ActivaExplosion()
    {
        activaExplosion = true;
    }

    
}