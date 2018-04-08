using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBoss : MonoBehaviour {

    public int speed;
	private Vector3 vectorDirector;
    public float angulo;
    public float seno;
    public float coseno;
    private Vector3 target;
    private SpriteRenderer render;

    

	void Start ()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        angulo = transform.rotation.z;
        target = new Vector3(coseno = Mathf.Cos(angulo), seno = Mathf.Sin(angulo), 0).normalized;
	}
	
	
	void Update ()
    {
        int direccion;
        if (Boss2Behaviour.Flip == false)
        {
            direccion = -1;
            render.flipX = false;
        }
        else
        {
            direccion = 1;
            render.flipX = true;
        }
        transform.position += target * speed * direccion * Time.deltaTime;
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
