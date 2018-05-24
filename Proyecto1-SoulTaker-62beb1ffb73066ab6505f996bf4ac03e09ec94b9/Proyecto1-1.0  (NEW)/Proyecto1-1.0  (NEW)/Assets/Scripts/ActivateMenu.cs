using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateMenu : MonoBehaviour {

    public GameObject menu;
    public bool Active = false;
    Scene scene;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        
        menu.SetActive(Active);
        scene = SceneManager.GetActiveScene();
        
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.M) && scene.name == "Tienda")
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
