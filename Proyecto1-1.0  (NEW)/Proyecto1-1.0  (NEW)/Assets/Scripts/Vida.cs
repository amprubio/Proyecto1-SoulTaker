using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{

    
    public int VidaInicio = 5;

    private int CorazonesMax = 8;
    private int VidaMaxima;
    private int VidaPorCorazon = 2; //Mitades

    public Image[] imagenVidas;
    public Sprite[] spriteVidas;
    [HideInInspector]
    public int VidaActual;
    static public bool Colision;
    Escudo esc;
    

    

    

    void Start()
    {
        VidaActual = VidaInicio * VidaPorCorazon;
        VidaMaxima = CorazonesMax * VidaPorCorazon;
        CalculaVida();
        esc = GameObject.Find("Player").GetComponent<Escudo>();
    }
    void CalculaVida()
    {
        for (int i = 0; i < CorazonesMax; i++)
        {
            if (VidaInicio <= i)
            {
                imagenVidas[i].enabled = false;
            }
            else
            {
                imagenVidas[i].enabled = true;
            }
        }
        ActualizaCorazones();
    }
    void ActualizaCorazones()
    {
        bool vacio = false;
        int j;
        int x = 0;
       
        for (j = 0; j < imagenVidas.Length; j++)
        {
            if (vacio)
            {
                imagenVidas[j].sprite = spriteVidas[0];
            }
            else
            {
                x++;
                x = Mathf.Clamp(x, 1, CorazonesMax);
                if (VidaActual > (x * VidaPorCorazon))
                {
                    imagenVidas[j].sprite = spriteVidas[2];
                }
                else if (VidaActual == (x * VidaPorCorazon))
                {
                    imagenVidas[j].sprite = spriteVidas[2];
                    vacio = true;
                }
                else
                {
                    imagenVidas[j].sprite = spriteVidas[1];
                    vacio = true;
                }
            }
        }
    }
    public void AniadeCorazon()
    {
        VidaInicio++;
        VidaInicio = Mathf.Clamp(VidaInicio, 0, CorazonesMax);

        CalculaVida();
    }
    //El player recibe daño del enemigo mediante este OnCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !esc.ActivadoEscudo)
        {
            EnemyLifeSystem enemy = collision.gameObject.GetComponent<EnemyLifeSystem>();
            VidaActual = VidaActual - enemy.EnemyDamage;
            VidaActual = Mathf.Clamp(VidaActual, 0, VidaMaxima);
            ActualizaCorazones();
            Colision = true;
        }
        //else if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "Thorns")
        else Colision = false;
        if(VidaActual <= 0)
        {
            DestroyPlayer();
            SceneManager.LoadScene(0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Proyectile")
        {
            ProyectilBoss pro = collision.gameObject.GetComponent<ProyectilBoss>();
            VidaActual = VidaActual - pro.damage;
            VidaActual = Mathf.Clamp(VidaActual, 0, VidaMaxima);
            ActualizaCorazones();
            Colision = true;
        }
        else Colision = false;
        if (VidaActual <= 0)
        {
            DestroyPlayer();
            SceneManager.LoadScene(0);
        }
    }

    public void CurarVida()
    {
        int y;
        y = VidaPorCorazon * VidaInicio;
        y = Mathf.Clamp(y, 0, VidaPorCorazon * VidaInicio);

        VidaActual = y;

        ActualizaCorazones();
        
    }
    public void DestroyPlayer()
    {
        imagenVidas[0].sprite = spriteVidas[0];
        Destroy(gameObject);
        
    }


}
