using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaManager : MonoBehaviour {
    
    //public static int VidaInicio;
    public static int currentHealth;
    public static int maxHealth;
    public int initialMaxHealth = 10;
    private bool emptyHeart;
    //private int heart;

    //private int CorazonesMax = 8;

    //private int VidaPorCorazon = 2; //Mitades

    public Image[] healthImages;
    public Sprite[] healthSprites;
    [HideInInspector]

    //static public bool Colision;



    //void Start()
    //{
    //    actualHealth = VidaInicio * VidaPorCorazon;
    //    maxHealth = CorazonesMax * VidaPorCorazon;
    //    CalculaVida();

    //}
    //public void CalculaVida()
    //{
    //    for (int i = 0; i < CorazonesMax; i++)
    //    {
    //        if (VidaInicio <= i)
    //        {
    //            imagenVidas[i].enabled = false;
    //        }
    //        else
    //        {
    //            imagenVidas[i].enabled = true;
    //        }
    //    }
    //    ActualizaCorazones();
    //}
    //public void ActualizaCorazones()
    //{
    //    GameManager.instance.VidaInicio = VidaInicio;
    //    bool vacio = false;
    //    int j;
    //    int x = 0;

    //    for (j = 0; j < imagenVidas.Length; j++)
    //    {
    //        if (vacio)
    //        {
    //            imagenVidas[j].sprite = spriteVidas[0];
    //        }
    //        else
    //        {
    //            x++;
    //            x = Mathf.Clamp(x, 1, CorazonesMax);
    //            if (actualHealth > (x * VidaPorCorazon))
    //            {
    //                imagenVidas[j].sprite = spriteVidas[2];
    //            }
    //            else if (actualHealth == (x * VidaPorCorazon))
    //            {
    //                imagenVidas[j].sprite = spriteVidas[2];
    //                vacio = true;
    //            }
    //            else
    //            {
    //                imagenVidas[j].sprite = spriteVidas[1];
    //                vacio = true;
    //            }
    //        }
    //    }

    //    GameManager.instance.VidaPlayer = actualHealth;
    //    GameManager.instance.VidaInicio = VidaInicio;

    //}
    //public void AniadeCorazon()
    //{
    //    VidaInicio++;
    //    GameManager.instance.VidaInicio = VidaInicio;
    //    VidaInicio = Mathf.Clamp(VidaInicio, 0, CorazonesMax);
    //    GameManager.instance.VidaInicio = VidaInicio;
    //    CalculaVida();
    //}

    //public void CurarVida()
    //{
    //    int y;
    //    y = VidaPorCorazon * VidaInicio;
    //    y = Mathf.Clamp(y, 0, VidaPorCorazon * VidaInicio);

    //    actualHealth = y;



    //    ActualizaCorazones();

    //}
    //public void DestroyPlayer()
    //{
    //    //healthImages[0].sprite = healthSprites[0];

    //}
    


    private void Start()
    {
        //GameManager.instance.maxHealth = initialMaxHealth;
        maxHealth = GameManager.instance.maxHealth;
        GameManager.instance.health = maxHealth;
        DrawHealth();
    }


    private void Update()
    {
        if (currentHealth != GameManager.instance.health)
        {
            DrawHealth();
        }
    }

    void DrawHealth()
    {
        currentHealth = GameManager.instance.health;
        healthImages = new Image [GameManager.instance.maxHealth/2];
        int heart = 0;
        emptyHeart = false;

        for(int i= 0; i < healthImages.Length; i++)
        {
            healthImages[i] = gameObject.transform.GetChild(i).GetComponent<Image>();
            healthImages[i].enabled = true;

            if (emptyHeart)
            {
                healthImages[i].sprite = healthSprites[0];
            }
            else
            {
                heart++;
                heart = Mathf.Clamp(heart, 1, healthImages.Length);

                if (currentHealth > (heart * 2))
                {
                    healthImages[i].sprite = healthSprites[2];
                }
                else if (currentHealth == (heart * 2))
                {
                    healthImages[i].sprite = healthSprites[2];
                    emptyHeart = true;
                }
                else if (currentHealth <= 0)
                {
                    healthImages[0].sprite = healthSprites[0];
                }
                else
                {
                    healthImages[i].sprite = healthSprites[1];
                    emptyHeart = true;
                }
            }
        }
    }

    public void RestoreHealth()
    {
        GameManager.instance.health = GameManager.instance.maxHealth;
    }

}
