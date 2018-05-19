using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsManager : MonoBehaviour {

    public static int CurrentPotions;
    public static int MaximumPotions;
    
    public Image[] potions;
    public Sprite[] potionGUI;

    void Start()
    {
        
        CurrentPotions = MaximumPotions;
        CalculatePotions();
        
    }

    public void CalculatePotions()
    {
        for (int i = 0; i < MaximumPotions; i++)
        {
            if (MaximumPotions <= i)
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

    public void UpdatePotions()
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

        GameManager.instance.NumPociones = CurrentPotions;
    }
}
