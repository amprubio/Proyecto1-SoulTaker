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
        InvocaBoom();
    }

    public void InvocaBoom()
    {
        if (Vector3.Distance(transform.position, target.position) < attack1Range)
        {
            Invoke("ActivaExplosion", 1f);
            Boom();
        }
    }

    public void Boom()
    {
        if (Vector3.Distance(transform.position, target.position) < attack1Range && activaExplosion == true)
        {
            explosion = GameObject.Instantiate(objectExplosion);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
        activaExplosion = false;
    }

    public void ActivaExplosion()
    {
        activaExplosion = true;
    }
}