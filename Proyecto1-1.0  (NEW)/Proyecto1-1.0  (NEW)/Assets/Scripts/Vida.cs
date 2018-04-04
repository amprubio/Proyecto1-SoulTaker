using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    
    public int VidaInicio = 5;
    public int VidaActual;

    private int CorazonesMax = 8;
    private int VidaMaxima;
    private int VidaPorCorazon = 2; //Mitades

    public Image[] imagenVidas;
    public Sprite[] spriteVidas;

    //public Enemy dmg;

    void Start()
    {
        VidaActual = VidaInicio * VidaPorCorazon;
        VidaMaxima = CorazonesMax * VidaPorCorazon;
        CalculaVida();
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
        if (VidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AniadeCorazon()
    {
        VidaInicio++;
        VidaInicio = Mathf.Clamp(VidaInicio, 0, CorazonesMax);

        CalculaVida();
    }
    /* Se implementara cuando los enemigos hagan daño.
    public void SufreDanio()
    {
        VidaActual= VidaActual - dmg.DañoEnemigo;
        VidaActual = Mathf.Clamp(VidaActual, 0, VidaMaxima);

        ActualizaCorazones();
    }*/
    public void CurarVida()
    {
        int y;
        y = VidaPorCorazon * VidaInicio;
        y = Mathf.Clamp(y, 0, VidaPorCorazon * VidaInicio);

        VidaActual = y;

        ActualizaCorazones();
        
    }


}
