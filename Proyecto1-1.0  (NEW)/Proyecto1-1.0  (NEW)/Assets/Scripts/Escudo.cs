using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    Collider2D colPlayer;
    float Duracion;
    float temp;
    public bool ActivadoEscudo = false;
    ParticleSystem escudoParticulas;
    ParticleSystem subParticulas;
	
	
    void Start()
    {
        escudoParticulas = gameObject.transform.GetChild(2).GetComponent<ParticleSystem>();
        colPlayer = GetComponent<Collider2D>();
        Duracion = escudoParticulas.time;
        subParticulas = gameObject.transform.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();
       

    }

	
    public void ActivaEscudo()
    {
        ActivadoEscudo = true;
        escudoParticulas.Play();
    }

    public void DesactivaEscudo()
    {
        ActivadoEscudo = false;
        escudoParticulas.Stop();
        subParticulas.Stop();
    }
    
}
