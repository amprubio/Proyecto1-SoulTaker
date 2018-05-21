using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada_Movement : MonoBehaviour {
    

    public float anguloSalida;
    public float fuerzaSalida;
    public GameObject prefabExplosion;
    private Transform granada;
    public float radioExplosion;
    public float dañoGranada;

    private float posX;
    private float posY;
    private float anguloConvertido;
    private Rigidbody2D rb;
    private Vector2 posLanzamiento;
    private bool flipped;
    private Collider2D col;
    
   

    void Start ()
    {
        float axisX = GameInputManager.MainHorizontal();
        if (axisX <= 0)
        {
            flipped = true;
        }
        else if (axisX >= 0)
        {
            flipped = false;
        }

       
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        Lanzamiento();
    }
    public void Lanzamiento()
    {
	    

        int cambiaDireccion = 1;

        //if (flipped)
        //{
        //    anguloSalida = 135;
        //}



        anguloConvertido = anguloSalida;
        posX = Mathf.Cos(anguloConvertido * Mathf.Deg2Rad);
        posY = Mathf.Sin(anguloConvertido * Mathf.Deg2Rad);
        posLanzamiento = new Vector2(posX, posY);

        
        rb.AddForce(posLanzamiento.normalized * fuerzaSalida * cambiaDireccion, ForceMode2D.Impulse);

        //Explosion();   
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);

    }


    void Explosion()
    {
        Instantiate(prefabExplosion, granada.transform.position, Quaternion.identity);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);

        foreach(Collider2D objetoCercano in colliders)
        {
            if(objetoCercano.tag == "Enemy")
            {
                EnemyLifeSystem enm = objetoCercano.GetComponent<EnemyLifeSystem>();
                enm.LoseHealth(dañoGranada);
            }
                
        }



        Destroy(this.gameObject, 0f);
        Destroy(prefabExplosion.gameObject, 1f);
    }
}


