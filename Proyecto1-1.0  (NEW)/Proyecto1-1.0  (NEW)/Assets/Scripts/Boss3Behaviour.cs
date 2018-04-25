using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behaviour : MonoBehaviour {

    public GameObject Pinchos1;
    public GameObject Pinchos2;
    int pinchosElegidos;
    Animator anim1, anim2;
    bool booleanoPinchos = true;
    // Use this for initialization
    void Start () {
        anim1 = Pinchos1.GetComponent<Animator>();
        anim2 = Pinchos2.GetComponent<Animator>();
        InvokeRepeating("EligePinchos", 3f, 4f);
	}

    private void Update()
    {
        if (pinchosElegidos == 1 || pinchosElegidos == 2)
        {
            InvocaSalidas();
        }
    }

    void EligePinchos()
    {
        pinchosElegidos = Random.Range(1, 3);
    }

    void InvocaSalidas()
    {
        if (pinchosElegidos == 1)
        {
            Invoke("SalidaPinchos1", 0f);
        }
        else if (pinchosElegidos == 2)
        {
            Invoke("SalidaPinchos2", 0f);
        }
    }

    void SalidaPinchos1()
    {
        if(booleanoPinchos == true)
        {
            booleanoPinchos = false;
            anim1.SetTrigger("Activarse1");
            Invoke("EntradaPinchos1", 2f);
        }
    }

    void SalidaPinchos2()
    {
        if(booleanoPinchos == true)
        {
            booleanoPinchos = false;
            anim2.SetTrigger("Activarse2");
            Invoke("EntradaPinchos2", 2f);
        }
    }

    void EntradaPinchos1()
    {
        anim1.SetTrigger("Desactivarse1");
        booleanoPinchos = true;
    }

    void EntradaPinchos2()
    {
        anim2.SetTrigger("Desactivarse2");
        booleanoPinchos = true;
    }
}
