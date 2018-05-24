using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject go;
    Animation startAnim;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        startAnim = GameObject.FindObjectOfType<Animation>();
        DestroyImmediate(DontDestroy.instance.gameObject);
        DestroyImmediate(PauseManager.instance.gameObject);
    }

    private void Start()
    {
        eventSystem.SetSelectedGameObject(go);
        startAnim.Play();
        //FindObjectOfType<AudioManager>().Play("Menu");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Vertical")) { SelectionSFX(); }
        if (Input.GetButtonDown("Submit")) { ClickSFX(); }
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

    public void SelectionSFX()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Selection");
    }

    public void ClickSFX()
    {
        FindObjectOfType<AudioManager>().PlaySFX("Click");
    }
}
