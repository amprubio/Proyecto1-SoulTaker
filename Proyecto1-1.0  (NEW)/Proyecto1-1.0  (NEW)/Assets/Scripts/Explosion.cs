using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private Transform target;
    public float attack1Range = 1f;
    public GameObject objectExplosion;
    GameObject explosion;
    float time = 0;
    public float t = 2;
    int estado = 1;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        if (estado == 1)
        {
            time = 0;
            if (Vector3.Distance(transform.position, target.transform.position) < attack1Range)
            {
                estado = 2;
            }
        }
        else if (estado == 2)
        {
            time += Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) > attack1Range)
            {
                estado = 1;
            }
            if (time >= t)
            {
                Boom();
            }
        }
    }


    public void Boom()
    {
        explosion = GameObject.Instantiate(objectExplosion);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}