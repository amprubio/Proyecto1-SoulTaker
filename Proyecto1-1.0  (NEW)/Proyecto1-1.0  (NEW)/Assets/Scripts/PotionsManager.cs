using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsManager : MonoBehaviour {

    public static int currentPotions;
    public static int maxPotions;
    private bool emptyPotion;
    
    public Image[] potionsImages;
    public Sprite[] potionsSprites;

    //void Start()
    //{
    //    CurrentPotions = MaximumPotions;
    //    CalculatePotions();
    //}

    //public void CalculatePotions()
    //{
    //    for (int i = 0; i < MaximumPotions; i++)
    //    {
    //        if (MaximumPotions <= i)
    //        {
    //            potions[i].enabled = false;
    //        }
    //        else
    //        {
    //            potions[i].enabled = true;
    //        }
    //    }

    //    UpdatePotions();
    //}

    //public void UpdatePotions()
    //{
    //    bool vacio = false;
    //    int j;
    //    int x = 0;
        

    //    for (j = 0; j < potions.Length; j++)
    //    {
    //        if (vacio)
    //        {
    //            potions[j].sprite = potionGUI[0];
    //        }
    //        else
    //        {
    //            x++;
    //            x = Mathf.Clamp(x, 1, MaximumPotions);
    //            if (CurrentPotions >= x)
    //            {
    //                potions[j].sprite = potionGUI[1];
    //            }
    //            else
    //            {
    //                potions[j].sprite = potionGUI[0];
    //                vacio = true;
    //            }
    //        }
    //    }

    //    //GameManager.instance.NumPociones = CurrentPotions;
    //}

    private void Start()
    {
        maxPotions = GameManager.instance.maxPotions;
        GameManager.instance.potions = maxPotions;
        DrawPotions();
        Debug.Log(GameManager.instance.potions);
    }

    private void Update()
    {
        if (currentPotions != GameManager.instance.potions)
        {
            DrawPotions();
        }
    }

    void DrawPotions()
    {
        currentPotions = GameManager.instance.potions;
        potionsImages = new Image[maxPotions];
        int potion = 0;
        emptyPotion = false;
        
        for(int i = 0; i < potionsImages.Length; i++)
        {
            potionsImages[i] = gameObject.transform.GetChild(i).GetComponent<Image>();

            if (emptyPotion)
            {
                potionsImages[i].sprite = potionsSprites[0];
            }
            else
            {
                potion++;
                potion = Mathf.Clamp(potion, 1, maxPotions);

                if (currentPotions >= potion)
                {
                    potionsImages[i].sprite = potionsSprites[1];
                }
                else if (currentPotions <= 0)
                {
                    potionsImages[0].sprite = potionsSprites[0];
                }
                else
                {
                    potionsImages[i].sprite = potionsSprites[0];
                    emptyPotion = true;
                }
            }
        }
    }

    public void RestorePotions()
    {
        GameManager.instance.potions = GameManager.instance.maxPotions;
    }
}
