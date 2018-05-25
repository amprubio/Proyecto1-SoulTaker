using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{

    static public bool Colision;

    public int VidaInicio;

    VidaManager vidaManager;
    Escudo esc;
    
    void Start()
    {
        vidaManager = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
        //VidaManager.VidaInicio = VidaInicio;
        esc = GameObject.Find("Player").GetComponent<Escudo>();
    }
    

    //El player recibe daño del enemigo mediante este OnCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !esc.ActivadoEscudo)
        {
            EnemyLifeSystem enemy = collision.gameObject.GetComponent<EnemyLifeSystem>();
            //VidaManager.VidaActual = VidaManager.VidaActual - enemy.EnemyDamage;
            //VidaManager.VidaActual = Mathf.Clamp(VidaManager.VidaActual, 0, VidaManager.VidaMaxima);
            //vidaManager.ActualizaCorazones();
            FindObjectOfType<AudioManager>().PlaySFX("PlayerDamage");
            GameManager.instance.UpdateHealth(VidaManager.currentHealth - enemy.EnemyDamage);
            Colision = true;
            Debug.Log(GameManager.instance.health);
        }
        //else if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "Thorns")
        else Colision = false;
        if(/*VidaManager.VidaActual <= 0*/GameManager.instance.health<=0)
        {
            DestroyPlayer();
            SceneManager.LoadScene(0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Proyectile")
        {
            ProyectilBoss pro = collision.gameObject.GetComponent<ProyectilBoss>();
            //VidaManager.VidaActual = VidaManager.VidaActual - pro.damage;
            //VidaManager.VidaActual = Mathf.Clamp(VidaManager.VidaActual, 0, VidaManager.VidaMaxima);
            //vidaManager.ActualizaCorazones();
            FindObjectOfType<AudioManager>().PlaySFX("PlayerDamage");
            GameManager.instance.UpdateHealth(VidaManager.currentHealth - pro.damage);
            Colision = true;
        }
        else Colision = false;
        if (/*VidaManager.VidaActual <= 0*/GameManager.instance.health <= 0)
        {
            DestroyPlayer();
            SceneManager.LoadScene(1);
        }
    }

    
    public void DestroyPlayer()
    {
        //vidaManager.DestroyPlayer();
        Destroy(gameObject);
    }


}
