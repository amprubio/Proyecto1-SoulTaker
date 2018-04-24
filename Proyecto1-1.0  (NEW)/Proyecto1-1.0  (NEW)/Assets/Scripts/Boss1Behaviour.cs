
//arreglar parada en shoot();

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behaviour : MonoBehaviour {
	public Transform[] WayPoints= new Transform[6];
	public GameObject player;
	public SpriteRenderer bossSprite;
	private Transform nextWayPoint;
	public GameObject Proyectil;
	public int numberProyectiles = 5;
	public int currentWayPoint = 0;
	public static bool Flip;
	public Transform PuntoSpawn;
	private float angleOffset;
	private float minAngle;
	// Use this for initialization
	System.Random rnd= new System.Random();
	void Start () {
		Collider2D colBoss = gameObject.GetComponent<Collider2D>();
		nextWayPoint = WayPoints [1];
	}

	// Update is called once per frame
	void Update () {

		MoveBoss ();
	}
	void MoveBoss()
	{	
		//Le pone la correa al good boy
		Debug.DrawLine(player.transform.position, bossSprite.transform.position, Color.black);
		//Va para el nodo siguiente
		bossSprite.transform.position = Vector3.MoveTowards(bossSprite.transform.position, nextWayPoint.transform.position, 3 * Time.deltaTime);

		//IMPORTANTE TU NODO NUMERO 6 VA A SER EN EL QUE QUIERES QUE GIRE DE DERECHA A IZQUIERDA.
		//MIS NODOS ESTAN PUESTOS DE ESTA MANERA 7...6...1...2.5...4...3
		if (currentWayPoint == 6) {
			bossSprite.flipX = false;
			currentWayPoint = 0;
			nextWayPoint = WayPoints[currentWayPoint];

		}
		//TU NODO 3 VA A SER EN EL QUE QUIERES QUE GIRE DE DERECHA A IZQUIERDA
		if (currentWayPoint == 3) {
			bossSprite.flipX = true;
			Debug.Log ("Flipo");
			currentWayPoint = (currentWayPoint + 1) % WayPoints.Length;
			nextWayPoint = WayPoints[currentWayPoint];

		}
		if(transform.position == nextWayPoint.position)
		{
			//PACHUM PACHUM
			if (rnd.Next(-10, 10) > -9f){
				Shoot ();
			}
			currentWayPoint = (currentWayPoint + 1) % WayPoints.Length;
			nextWayPoint = WayPoints[currentWayPoint];
		}

	}
	private void Shoot()
	{
		//esto no sirve en verdad
		Flip = bossSprite.flipX;
		//Rotacion del boss hacia el player
		if(currentWayPoint<=WayPoints.Length)
			bossSprite.transform.position = Vector3.MoveTowards(bossSprite.transform.position, WayPoints[currentWayPoint-2].transform.position, 0 * Time.deltaTime);

			GameObject Proyectiles = (GameObject)Instantiate(Proyectil, bossSprite.transform.position, Quaternion.identity);

		}
		//float rotz = LookAtPlayer(bossSprite.flipX,direcc);
		//transform.rotation = Quaternion.AngleAxis(rotz, Vector3.forward);

		//angleOffset = 90 / numberProyectiles;
		//minAngle = rotz + ((numberProyectiles / 2) * angleOffset);

		//Hacia positivos min angulo = rotz - (numberProyectiles / 2) * angleOffset

		//if (rotz + (angleOffset * (i+1)) > 0)
		//{
		//    x = -rotaciónLocalProyectil;
		//}
		//else if ((rotz + (angleOffset * i)) == 0)
		//{
		//    x = 0;
		//}
		//else
		//{
		//    x = rotaciónLocalProyectil;
		//}
		//Proyectiles.transform.rotation = Quaternion.Euler(0, 0, minAngle - (angleOffset * i));



	}
	//esto no lo he usado tampoco pero bueno a lo mejor para los disparos teledirigdos sirve
