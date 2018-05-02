using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLand : MonoBehaviour {


    void OnCollisionStay2D(Collision2D coll)
    {
        SpriteRenderer currentenemy = coll.gameObject.GetComponent<SpriteRenderer>();
        if (coll.gameObject.CompareTag("Flip"))
        {
            if (currentenemy.flipX == true)
            {
                currentenemy.flipX = false;
            }
            else
                currentenemy.flipX = true;
        }
    }

}


    

