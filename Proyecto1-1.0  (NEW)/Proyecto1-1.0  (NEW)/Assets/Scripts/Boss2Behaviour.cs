using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behaviour : MonoBehaviour {

    [Header("Puntos para el moviento del Boss")]
    public Transform[] WayPoints = new Transform[7];
    public Transform PuntoSpawn;
    [Header("Atributos del Boss")]
    [Header("El anguloAperturaDisparo debe ser un número menor a 45")]
    [Header("La rotaciónLocalProyectil se encarga de rotar el sprite,")]
    [Header("si se pone un valor positivo el angulo se hace mas pequeño.")]
    public int anguloAperturaDisparo;
    public int rotaciónLocalProyectil;
    public int movementSpeed;
    public GameObject Proyectil;
    public SpriteRenderer bossSprite;
    
    [HideInInspector]
    public static bool Flip;

    
    public int currentWayPoint = 0;
    private Transform nextWayPoint;
    private int varSpeed;
    public float temp = 3f;
    public bool IsShooting = false;
    public Vector3 tempPos = new Vector3();
    public Vector3 posOffset = new Vector3();
    private float amplitude = 0.01f;
    private float frequency = 0.5f;
    


           
    
    
    void Start ()
    {
        varSpeed = movementSpeed;
        
        if (movementSpeed == 0) movementSpeed = 5;
	}
	
	

	void Update ()
    {
        if(currentWayPoint < WayPoints.Length)
        {
            if (nextWayPoint == null)
                nextWayPoint = WayPoints[currentWayPoint];
           switch(currentWayPoint)
           {
                case 2:
                case 6:
                    if (!IsShooting)
                    {
                        Shoot();
                        IsShooting = true;
                    }
                    if (temp > 0 && IsShooting == true)
                    {
                        temp = temp - Time.deltaTime;
                        IsShooting = true;
                    }
                    else
                    {
                        IsShooting = false;
                        temp = 3f;
                    }
                    Idle();
                    //MoveBoss(movementSpeed);
                    break;
                
                default:
                    MoveBoss(movementSpeed);
                    break;

                    


           }

            
        }
	}
    void MoveBoss(int sp)
    {
        transform.position = Vector3.MoveTowards(transform.position, nextWayPoint.position, sp * Time.deltaTime);

        if(transform.position == nextWayPoint.position)
        {
            
            currentWayPoint = (currentWayPoint + 1) % WayPoints.Length;
            nextWayPoint = WayPoints[currentWayPoint];
        }
    }
    private void Shoot()
    {
        int x = 0;
        int anguloBase = -45 + anguloAperturaDisparo;
        int desfaseAngulo = -anguloBase;
        Flip = bossSprite.flipX;
        for (int i = 0; i < 3; i++)
        {
            GameObject Proyectiles = (GameObject)Instantiate(Proyectil, PuntoSpawn.transform.position, Quaternion.identity);
            if (anguloBase + (desfaseAngulo * i) > 0)
            {
                x = -rotaciónLocalProyectil;
            }
            else if ((anguloBase + (desfaseAngulo * i)) == 0)
            {
                x = 0;
            }
            else
            {
                x = rotaciónLocalProyectil;
            }

            Proyectiles.transform.rotation = Quaternion.Euler(0, 0, anguloBase + (desfaseAngulo * i) + x);

        }
    }

    private void Idle()
    {
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

}
