using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    Collider2D colPlayer;
    float Duracion;
    float temp;
    public bool ActivadoEscudo = false;
    public ParticleSystem escudo;
	
	
    void Start()
    {
        colPlayer = GetComponent<Collider2D>();
        Duracion = escudo.time;

    }

	
	void Update ()
    {
		//if(InputManager.LBButton() && !ActivadoEscudo)
  //      {
  //          StartCoroutine(ActivaEscudo());
            
  //      }
        
	}

    IEnumerator ActivaEscudo()
    {
        ActivadoEscudo = true;
        Debug.Log("Tengoganasdematarte");
        escudo.Play();
        yield return new WaitForSeconds(escudo.main.duration);
        ActivadoEscudo = false;
        Debug.Log("Posyano");
    }
}
