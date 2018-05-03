using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {

    Vida vida;
    const int MaximumPotions = 3;
    ParticleSystem healingEffect;
    bool ActiveEffect = false;
    public float tempEffect = 0.75f;
    private int CurrentPotions;

    public Image[] potions;
    public Sprite[] potionGUI;

	void Start ()
    {
        vida = gameObject.GetComponent<Vida>();
        CurrentPotions = MaximumPotions;
        CalculatePotions();
        healingEffect = gameObject.GetComponent<ParticleSystem>();
        healingEffect.Pause();

	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            vida.CurarVida();
            CurrentPotions--;
            healingEffect.Play();
            Debug.Log("Me he tomado una pocion");
            
            UpdatePotions();
        }

        Debug.Log(healingEffect.isPlaying);
    }

    void CalculatePotions()
    {
        for(int i = 0; i < MaximumPotions; i++)
        {
            if(MaximumPotions <= i)
            {
                potions[i].enabled = false;
            }
            else
            {
                potions[i].enabled = true;
            }
        }

        UpdatePotions();
    }

    void UpdatePotions()
    {
        bool vacio = false;
        int j;
        int x = 0;

        for (j = 0; j < potions.Length; j++)
        {
            if (vacio)
            {
                potions[j].sprite = potionGUI[0];
            }
            else
            {
                x++;
                x = Mathf.Clamp(x, 1, MaximumPotions);
                if (CurrentPotions >= x)
                {
                    potions[j].sprite = potionGUI[1];
                }
                else
                {
                    potions[j].sprite = potionGUI[0];
                    vacio = true;
                }
            }
        }
    }


}
