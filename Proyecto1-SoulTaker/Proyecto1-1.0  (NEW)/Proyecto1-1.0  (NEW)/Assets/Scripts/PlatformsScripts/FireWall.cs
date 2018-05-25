using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour {

    public Animator animFire;
    public Animator animCrystal;

    // Use this for initialization
    void Start ()
    {
        animFire.SetBool("Off", false);
        animCrystal.SetBool("Off", false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            animFire.SetBool("Off", true);
            animCrystal.SetBool("Off", true);
        }
    }
}
