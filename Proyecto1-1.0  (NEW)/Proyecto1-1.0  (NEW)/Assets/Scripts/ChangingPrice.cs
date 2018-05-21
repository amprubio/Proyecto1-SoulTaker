using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangingPrice : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D cool) {
        if (cool.gameObject.CompareTag("Item"))
        {
            GetComponent<Preciotxt>().Changetext();
        }
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D cool) {

     Text txt = GetComponent<Text>();
        Destroy(txt, 1);
}
	}

