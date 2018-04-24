using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1Behaviour : MonoBehaviour {

	public int speed;
	public int damage;
	private Vector3 vectorDirector;

	public float angulo;
	public float seno;
	public float coseno;

	private Vector3 target;
	private SpriteRenderer render;
	private float tempDestroy = 10f;
	private bool Flipped;



	void Start ()
	{

		Flipped = Boss1Behaviour.Flip; 
		render = gameObject.GetComponent<SpriteRenderer>();
		angulo = transform.rotation.z;
		//target = new Vector3(coseno = Mathf.Cos(angulo)*Mathf.Deg2Rad, seno = Mathf.Sin(angulo)*Mathf.Deg2Rad, 0).normalized;
	}


	void Update ()
	{
		int direccion;
		if (!Flipped)
		{
			direccion = -1;
			render.flipX = false;
		}
		else
		{
			direccion = 1;
			render.flipX = true;
		}
		transform.position += transform.right * speed * direccion * Time.deltaTime;
		tempDestroy = tempDestroy - Time.deltaTime;
		if (tempDestroy < 0) Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}

	}


}
