using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Animator pauseMenu;
    public AnimationClip pauseOff;
    public static PauseManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (InputManager.StartButton())
        {
            if (GameIsPaused)
            {
                Continue();
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.visible = true;
            }
        }
	}

    public void Continue()
    {
        pauseMenu.SetBool("GamePaused", false);
        StartCoroutine(PauseAnimation());
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenu.SetBool("GamePaused", true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PauseAnimation()
    {
        yield return new WaitForSeconds(pauseOff.length);
    }
}
