
//arreglar parada en shoot();

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
	public int timeofshoot=10;
	public static bool Flip;
	public Transform PuntoSpawn;
	private Animator anim;
	private float angleOffset;
	private float minAngle;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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
		anim.SetBool("ataque",true);
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
			currentWayPoint = 4;
			nextWayPoint = WayPoints[currentWayPoint];

		}
		if(transform.position == nextWayPoint.position)
		{
			//PACHUM PACHUM

				Debug.Log ("PACHUUM");

				anim.SetBool ("disparo",true);
				Shoot ();


			currentWayPoint = (currentWayPoint + 1) % WayPoints.Length;
			nextWayPoint = WayPoints[currentWayPoint];
		}

	}
	private void Shoot()
	{
		Flip = bossSprite.flipX;
		Debug.DrawLine (WayPoints[currentWayPoint].position,nextWayPoint.position,Color.cyan);
		float count = 0;
		//esto no sirve en verdad
		while(count<timeofshoot){
			anim.SetBool ("descanso",true);
			bossSprite.transform.position = Vector3.MoveTowards(WayPoints[currentWayPoint].transform.position, WayPoints[currentWayPoint-1].transform.position, 0.001f* Time.deltaTime);
			count += Time.deltaTime;
			}	
		MoveBoss ();
		}
	void Sh(){
	Vector3 direcc = player.transform.position - PuntoSpawn.transform.position;
		float angle= 90 / numberProyectiles;
		transform.rotation= Quaternion.AngleAxis(angle,Vector3.forward);

	

	//Hacia positivos min angulo = rotz - (numberProyectiles / 2) * angleOffset
	for (int i = 0; i < numberProyectiles; i++)
	{
		GameObject Proyectiles = (GameObject)Instantiate(Proyectil, PuntoSpawn.transform.position, Quaternion.identity);
		

	}

}
}
	//esto no lo he usado tampoco pero bueno a lo mejor para los disparos teledirigdos sirve
