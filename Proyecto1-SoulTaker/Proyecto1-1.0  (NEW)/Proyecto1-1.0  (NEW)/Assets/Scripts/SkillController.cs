using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SkillController : MonoBehaviour {

    public List<Skill> skills;

    MovementController movementController;
    Escudo escudo;
    Scene sc;

    

	void Start ()
    {
        movementController = GameObject.Find("Player").GetComponent<MovementController>();
        escudo = GameObject.Find("Player").GetComponent<Escudo>();

        foreach (Skill s in skills)
        {
            s.currentCooldown = s.cooldown;
        }

        sc = SceneManager.GetActiveScene();
    }
	
	
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.R) && !escudo.ActivadoEscudo)
        {
            if(skills[0].currentCooldown >= skills[0].cooldown)
            {
                escudo.ActivaEscudo();
                skills[0].currentCooldown = 0;
            }else if(skills[0].currentCooldown >= 5)
            {
                escudo.DesactivaEscudo();
            }
        }else if(GameInputManager.GetKeyDown("GranadeKey") || GameInputManager.JTriggers() < 0)
        {
            if (skills[1].currentCooldown >= skills[1].cooldown)
            {
                movementController.ActivaGranada();
                skills[1].currentCooldown = 0;
            }
        }
        
        ChangeSceneValues();

	}

    void Update()
    {
        foreach(Skill s in skills)
        {
            if(s.currentCooldown < s.cooldown)
            {
                s.currentCooldown = s.currentCooldown + Time.deltaTime;
                s.background.fillAmount = s.currentCooldown / s.cooldown;
            }
        }
    }
    
    void ChangeSceneValues()
    {
        if(sc != SceneManager.GetActiveScene())
        {
            movementController = GameObject.Find("Player").GetComponent<MovementController>();
            escudo = GameObject.Find("Player").GetComponent<Escudo>();
            sc = SceneManager.GetActiveScene();
        }
    }

}

[System.Serializable]
public class Skill
{
    public Image background;
    public float cooldown;
    [HideInInspector]
    public float currentCooldown;
}
