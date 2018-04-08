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
    public float movementSpeed;
    public GameObject Proyectil;
    public SpriteRenderer bossSprite;
    
    [HideInInspector]
    public static bool Flip;

    
    public int currentWayPoint = 0;
    private Transform nextWayPoint;
    public float varSpeedUp;
    public float tempShooting = 3f;
    public float tempIdle = 3f;
    public bool IsShooting = false;
    public bool IsIdle = false;
    public Vector3 tempPos = new Vector3();
    public Vector3 posOffset = new Vector3();
    private float amplitude = 0.01f;
    private float frequency = 0.5f;
    private float acceleration = 0.1f;
    
    void Start ()
    {
        varSpeedUp = movementSpeed;
        
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
                        Idle();
                        tempIdle = tempIdle - Time.deltaTime;
                        IsIdle = true;
                    }
                    else
                    {
                        MoveBoss(movementSpeed);
                    }                   
                    break;
                case 5:
                    bossSprite.flipX = true;
                    MoveBoss(movementSpeed);
                    RestartValues();
                    break;
                case 1:
                    bossSprite.flipX = false;
                    if(varSpeedUp > movementSpeed && varSpeedUp > 1) varSpeedUp = varSpeedUp - 35 * acceleration;
                    MoveBoss(varSpeedUp);
                    RestartValues();
                    break;
                case 0:
                    if(varSpeedUp < 15) varSpeedUp = varSpeedUp + acceleration;
                    MoveBoss(varSpeedUp);
                    break;

                default:
                    MoveBoss(movementSpeed);
                    break;
           }

            
        }
	}
    void MoveBoss(float sp)
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
    private void RestartValues()
    {
        IsShooting = false;
        IsIdle = false;
        tempIdle = 3f;
        tempShooting = 3f;
        varSpeedUp = movementSpeed;
    }

}
