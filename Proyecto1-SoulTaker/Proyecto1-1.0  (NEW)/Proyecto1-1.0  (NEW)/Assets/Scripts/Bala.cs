using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {



    public int damage;
    public float velocidad = 70f;
    public GameObject Impacto;
    

    [HideInInspector]
    public Vector3 posinicialobj;
    public Vector3 direccion;
    public float espRecorrido;
    public Transform objetivoBala; //Avatar

    

    public void ObtieneObjetivo(Transform obj)
    {
        objetivoBala = obj;
    }

    private void Start()
    {        
        posinicialobj = objetivoBala.position;
        direccion = posinicialobj - transform.position;
        espRecorrido = velocidad * Time.deltaTime;
    }

    
	void Update ()
    {
        transform.Translate(direccion.normalized * espRecorrido, Space.World);
	}

    void ObjetivoAlcanzado()//Particulas
    {
        GameObject ins = Instantiate(Impacto, transform.position, transform.rotation);
        
        Destroy(ins, 2f);
        Destroy(gameObject);
    }

    private void Choque()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ObjetivoAlcanzado();
        }
        else if (collision.gameObject.tag != "Enemy")
        {
            Choque();
        }
    }


}
