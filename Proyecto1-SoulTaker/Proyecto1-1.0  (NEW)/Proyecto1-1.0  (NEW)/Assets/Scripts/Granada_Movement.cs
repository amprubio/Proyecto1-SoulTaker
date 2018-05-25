using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada_Movement : MonoBehaviour {
    

    public float anguloSalida;
    public float fuerzaSalida;
    public GameObject particulasExplosion;
    private Transform granada;
    public float radioExplosion;
    public float dañoGranada;

    private float posX;
    private float posY;
    private float anguloConvertido;
    private Rigidbody2D rb;
    private Vector2 posLanzamiento;
    public bool flipped;
    private Collider2D col;
    private SpriteRenderer playerRenderer;
   

    void Start ()
    {
        float axisX = GameInputManager.MainHorizontal();
        playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        flipped = playerRenderer.flipX;

        

        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        Lanzamiento();
    }
    public void Lanzamiento()
    {
	    

        int cambiaDireccion = 1;

        if (flipped)
        {
            anguloSalida = 135;
        }



        anguloConvertido = anguloSalida;
        posX = Mathf.Cos(anguloConvertido * Mathf.Deg2Rad);
        posY = Mathf.Sin(anguloConvertido * Mathf.Deg2Rad);
        posLanzamiento = new Vector2(posX, posY);

        
        rb.AddForce(posLanzamiento.normalized * fuerzaSalida * cambiaDireccion, ForceMode2D.Impulse);

           
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Explosion();
        

    }


    void Explosion()
    {

        Instantiate(particulasExplosion, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);

        foreach(Collider2D objetoCercano in colliders)
        {
            if(objetoCercano.tag == "Enemy")
            {
                EnemyLifeSystem enm = objetoCercano.GetComponent<EnemyLifeSystem>();
                enm.LoseHealth(dañoGranada);
            }
                
        }



        Destroy(gameObject);
       
    }
}


