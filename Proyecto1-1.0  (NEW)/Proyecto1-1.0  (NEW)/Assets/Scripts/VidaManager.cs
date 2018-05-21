using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaManager : MonoBehaviour {


    public static int VidaInicio;
    public static int VidaActual;
    public static int VidaMaxima;

    private int CorazonesMax = 8;
    
    private int VidaPorCorazon = 2; //Mitades

    public Image[] imagenVidas;
    public Sprite[] spriteVidas;
    [HideInInspector]
    
    static public bool Colision;
    
    

    void Start()
    {
        VidaActual = VidaInicio * VidaPorCorazon;
        VidaMaxima = CorazonesMax * VidaPorCorazon;
        CalculaVida();
        
    }
    public void CalculaVida()
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
    public void ActualizaCorazones()
    {
        GameManager.instance.VidaInicio = VidaInicio;
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

        GameManager.instance.VidaPlayer = VidaActual;
        GameManager.instance.VidaInicio = VidaInicio;

    }
    public void AniadeCorazon()
    {
        VidaInicio++;
        GameManager.instance.VidaInicio = VidaInicio;
        VidaInicio = Mathf.Clamp(VidaInicio, 0, CorazonesMax);
        GameManager.instance.VidaInicio = VidaInicio;
        CalculaVida();
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

    }
}
