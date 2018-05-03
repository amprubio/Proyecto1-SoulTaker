using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public static bool GameIsPausedOnMain = false;
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
            if (GameIsPausedOnMain)
            {
                Continue();
            }
            else/* if(!GameIsPausedOnMain)*/
            {
                Pause();
            }
        }
	}

    public void Continue()
    {
        StartCoroutine(PauseAnimation());
        Time.timeScale = 1f;
        GameIsPausedOnMain = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenu.SetBool("GamePaused", true);
        Time.timeScale = 0f;
        GameIsPausedOnMain = true;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PauseAnimation()
    {
        pauseMenu.SetBool("GamePaused", false);
        yield return new WaitForSeconds(pauseOff.length);
    }
}
