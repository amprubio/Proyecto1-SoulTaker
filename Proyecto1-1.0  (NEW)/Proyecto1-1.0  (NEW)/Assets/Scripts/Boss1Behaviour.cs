
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
    public float speed = 1f;
	public GameObject Proyectil;
	public int numberProyectiles = 5;
	public int currentWayPoint = 0;
	public int timeofshoot=5;
	public static bool Flip;
	public Transform PuntoSpawn;
	private float angleOffset;
	private float minAngle;
    private int incr = 1;
    Animator anim;
    private float varSpeed;
    Vector3 tempPos;
    //temps
    float tempAnim;
    float tempIdle = 3f;
    float tempShooting;
    bool IsShooting = false;
    bool IsIdle = false;
    public int random;
	[HideInInspector]
	public bool deadboss1 = false;
    System.Random rnd= new System.Random();

    void Start () {
		Collider2D colBoss = gameObject.GetComponent<Collider2D>();
        transform.position = WayPoints[0].transform.position;
        nextWayPoint = WayPoints[1].transform;
        anim = gameObject.GetComponent<Animator>();
        varSpeed = speed;
	}

	// Update is called once per frame
	void Update ()
    {
		while (GetComponent<EnemyLifeSystem> ().CurrentHealth > 0) {
			Fase2 ();

			random = rnd.Next (0, 11);
			if (currentWayPoint == 0) {
				if (random < 5) {
					Fase1 ();
				}
            
			}
		}
		Destroy (this.gameObject);
	}
	void OnDestroy(){
		deadboss1 = true;
	}

	void MoveBoss(float speedM)
	{
        transform.position = Vector3.MoveTowards(transform.position, nextWayPoint.position, speedM * Time.deltaTime);

        

        if (transform.position == nextWayPoint.position)
        {
            if(currentWayPoint == 0)
            {
                incr = 1;
            }
            else if(currentWayPoint == 5 )
            {
                incr = -1;
            }

            currentWayPoint = currentWayPoint + incr;
            nextWayPoint = WayPoints[currentWayPoint];
        }

    }
	private void Shoot()
	{

        
        //Rotacion del boss hacia el player
        Vector3 direcc = player.transform.position - PuntoSpawn.transform.position;
        float rotz = LookAtPlayer(bossSprite.flipX, direcc);
        

        angleOffset = 90 / numberProyectiles;
        minAngle = rotz + ((numberProyectiles / 2) * angleOffset);

        //Hacia positivos min angulo = rotz - (numberProyectiles / 2) * angleOffset
        for (int i = 0; i < numberProyectiles; i++)
        {
            GameObject Proyectiles = (GameObject)Instantiate(Proyectil, PuntoSpawn.transform.position, Quaternion.identity);
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
            Proyectiles.transform.rotation = Quaternion.Euler(0, 0, minAngle - (angleOffset * i));

        }
    }

    void Fase1()
    {
        switch(currentWayPoint)
        {
            case 0:

                //Animacion de carga
               
                MoveBoss(speed);
                break;

            default:
                //Animacion de andar
                varSpeed += 3;
                MoveBoss(varSpeed);
                break;

        }

    }
    void Fase2()
    {
        switch (currentWayPoint)
        {
            case 0:
                bossSprite.flipX = false;
                MoveBoss(speed);
                RestartValues();
                
                
                break;
            case 1:
            case 4:

                //Animacion de disparo
                if (!IsShooting)
                {
                    Shoot();


                    IsShooting = true;
                }
                if (tempShooting > 0 && IsShooting == true)
                {
                    tempShooting = tempShooting - Time.deltaTime;
                    IsShooting = true;
                }
                else
                {
                    IsShooting = false;
                    tempShooting = 3f;
                }
                if (tempIdle > 0)
                {
                    
                    tempIdle = tempIdle - Time.deltaTime;
                    IsIdle = true;
                }
                else
                {
                    MoveBoss(speed);
                }
                break;

            case 6:
                bossSprite.flipX = true;
                MoveBoss(speed);
                RestartValues();
                break;

            default:
                //Animacion de andar
                RestartValues();
                MoveBoss(speed);
                break;

        }

    }
    

    private float LookAtPlayer(bool flip, Vector3 angBase)
    {

        angBase.Normalize();
        float rotz = Mathf.Atan2(angBase.y, angBase.x) * Mathf.Rad2Deg;

        if (!flip)
        {
            rotz = rotz + 180;
        }


        return rotz;

    }

    private void RestartValues()
    {
        IsShooting = false;
        IsIdle = false;
        tempIdle = 3f;
        tempShooting = 3f;
        
    }

}
	
