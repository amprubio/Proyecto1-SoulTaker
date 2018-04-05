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

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void LoseHealth(int i)
    {
        CurrentHealth = CurrentHealth - i;
        Debug.Log("CurrentHealth - i : " + CurrentHealth);
        if (CurrentHealth <= 0) Destroy(this.gameObject);
    }
    
}
