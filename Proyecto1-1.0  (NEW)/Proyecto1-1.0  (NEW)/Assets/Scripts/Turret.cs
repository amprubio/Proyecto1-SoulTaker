using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    
    [Header("Turret Script --> TommySeed || Bala Script-- > Bala")]
    [Header("El GameObject vacío ParteARotar contiene sprite Cabeza.")]
    [Header("No gira la cabeza sino el GO vacio.")]
    [Header("Angulo del GO vacio Rotacion(0,90,0)")]
    [Header("El puntero marca de donde se instancia las balas y el raycast.")]
    
    [Header("Atributos")]
    public float rango = 15f;
    public float cadencia = 2f;
    private float contCadencia;

    [Header("Variables de Unity")]
    public string tagPlayer = "Player";
    private Transform objetivo;
    public GameObject balaPrefab;
    public Transform puntoInstanciado;
    public GameObject ParteARotar;
    


    //[HideInInspector]
    public bool HaEntrado = false;
    public Vector3 direccion;




    void Start ()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        CircleCollider2D col = gameObject.GetComponent<CircleCollider2D>();
        col.radius = rango;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (objetivo == null)
            return;



        if(HaEntrado)
        {
            

            Vector3 dir = objetivo.position - transform.position;
           Quaternion anguloRotacion = Quaternion.LookRotation(dir);
           Vector3 rotacion = anguloRotacion.eulerAngles;
           ParteARotar.transform.rotation = Quaternion.Euler (0f,0f,rotacion.z);
           if(CanSeePlayer())
           {
                if (contCadencia <= 0)
                {
                    Dispara();
                    contCadencia = 1f / cadencia;
                }

                contCadencia = contCadencia - Time.deltaTime;
           }
            
        }
        

	}

    void Dispara()
    {
        GameObject balaGO = (GameObject)Instantiate(balaPrefab, puntoInstanciado.position, puntoInstanciado.rotation);
        Bala bala = balaGO.GetComponent<Bala>();

        if (balaGO != null)
            bala.objetivoBala = objetivo;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
        Gizmos.DrawRay(puntoInstanciado.transform.position, direccion);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HaEntrado = true;
        }
        
        
        return;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HaEntrado = false;
        }
        return;
    }

    public bool CanSeePlayer()
    {
        bool InterrumpeRay = false;
        direccion = objetivo.position - puntoInstanciado.transform.position; 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, Mathf.Infinity);

        if (hit.transform.position != objetivo.transform.position)
        {
            InterrumpeRay = true;
        }
        else InterrumpeRay = false;

        return InterrumpeRay;
    }


}
