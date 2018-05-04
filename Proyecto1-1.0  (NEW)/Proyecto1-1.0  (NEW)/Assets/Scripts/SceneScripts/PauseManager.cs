using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    
    public GameObject pauseMenuUI;
    public Animator pauseMenu;
    public AnimationClip pauseOff;
    public static PauseManager instance;

    void Awake()
    {

        if (instance == null && SceneManager.GetActiveScene().buildIndex > 0)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (InputManager.StartButton())
        {
            if (pauseMenuUI.activeSelf)
            {
                Continue();
            }
            else if (!pauseMenuUI.activeSelf)
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        StartCoroutine(PauseAnimation());
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenu.SetBool("GamePaused", true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    IEnumerator PauseAnimation()
    {
        pauseMenu.SetBool("GamePaused", false);
        yield return new WaitForSeconds(pauseOff.length);
        pauseMenuUI.SetActive(false);
    }
}
