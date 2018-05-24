using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLayer : MonoBehaviour {

    SpriteRenderer color;
    GameObject foreground;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>();
        foreground = GameObject.FindGameObjectWithTag("Foreground");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            color.color=new Color(1f,1f,1f,0.5f);
            foreground.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            color.color = new Color(1f, 1f, 1f, 1f);
            foreground.SetActive(true);
        }
    }
}
