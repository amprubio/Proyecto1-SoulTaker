using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour {

    public GameObject menu;
    public bool Active = false;

    private void Start()
    {
        menu.SetActive(Active);
        
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            changeCanvasProperty(menu, Active);
            Active = !Active;
        }
        
    }

    void changeCanvasProperty(GameObject yourCanvas, bool disable)
    {
        if (disable)
            yourCanvas.SetActive(false);
        else
            yourCanvas.SetActive(true);
    }
}
