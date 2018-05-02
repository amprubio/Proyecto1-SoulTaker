using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private MovementController player;
    public static LevelManager instance;
    public Animator anim;

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
    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<MovementController>();
        Cursor.visible = false;
    }

    public void ExitLevel()
    {
        anim.SetBool("ExitLevel", true);
        StartCoroutine(TransitionTime(anim.GetCurrentAnimatorStateInfo(0).length+0.2f));
    }

    public void RespawnPlayer()  
    {
        player.transform.position = currentCheckpoint.transform.position;
    }

    IEnumerator TransitionTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
