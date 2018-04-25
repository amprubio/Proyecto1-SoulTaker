using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLifeSystem : MonoBehaviour {


    [Header("Daño = 1 --> Medio Corazón del Player")]
    public int EnemyDamage;
    [Header("Atributos de la vida del enemigo")]
    public int MaxHealth;
    [HideInInspector]
    public float CurrentHealth;
    public float souls;
    public float darkness;
    private Souls giveSouls;
    private Darkness giveDarkness;

    
    void Start()
    {
        SetInitialReferences();
    }

    private void OnDestroy()
    {
        GameManager.instance.AddDarkness(darkness);
        GameManager.instance.AddSouls(souls);
    }


    void SetInitialReferences()
    {
        CurrentHealth = MaxHealth;
    }

    public void LoseHealth(float i)
    {
        CurrentHealth = CurrentHealth - i;
        Debug.Log("CurrentHealth - i : " + CurrentHealth);
        if (CurrentHealth <= 0) Destroy(this.gameObject);
    }
    
}
