using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject go;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(go);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
