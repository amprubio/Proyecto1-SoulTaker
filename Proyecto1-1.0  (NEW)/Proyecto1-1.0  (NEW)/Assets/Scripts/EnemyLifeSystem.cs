using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLifeSystem : MonoBehaviour {


    [Header("Daño = 1 --> Medio Corazón del Player")]
    public int EnemyDamage;
    [Header("Atributos de la vida del enemigo")]
    public int MaxHealth;
    [HideInInspector]
    public int CurrentHealth;
    public float souls;
    public float darkness;
    //private Ataque playerDamage;
    private Souls giveSouls;
    private Darkness giveDarkness;

    // Use this for initialization
    void Start()
    {
        SetInitialReferences();
    }

    private void OnDestroy()
    {
        giveSouls.AddSouls(souls);
        giveDarkness.AddDarkness(darkness);
    }


    void SetInitialReferences()
    {
        giveSouls = GameObject.Find("UI").GetComponent<Souls>();
        giveDarkness = GameObject.Find("UI").GetComponent<Darkness>();

        CurrentHealth = MaxHealth;
    }

    public void LoseHealth(int i)
    {
        CurrentHealth = CurrentHealth - i;
        Debug.Log("CurrentHealth - i : " + CurrentHealth);
        if (CurrentHealth <= 0) Destroy(this.gameObject);
    }
    
}
