using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {

    VidaManager vidaManager;
    PotionsManager potionsManager;
    public int MaxPotions;
    ParticleSystem healingEffect;
    bool ActiveEffect = false;
    public float tempEffect = 0.75f;
    

    public Image[] potions;
    public Sprite[] potionGUI;

	void Start ()
    {
        
        vidaManager = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
        potionsManager = GameObject.Find("HUDCanvas").transform.GetChild(1).GetComponent<PotionsManager>();
        healingEffect = gameObject.transform.GetChild(3).GetComponent<ParticleSystem>();
        healingEffect.Pause();
        PotionsManager.MaximumPotions = MaxPotions;

	}


    void Update()
    {
        if (GameInputManager.GetKeyDown("HealKey") || GameInputManager.YButton())
        {
            
            vidaManager.CurarVida();
            PotionsManager.CurrentPotions--;
            Mathf.Clamp(PotionsManager.CurrentPotions, 0, MaxPotions);
            healingEffect.Play();

            potionsManager.UpdatePotions();
        }
    }
    
}
