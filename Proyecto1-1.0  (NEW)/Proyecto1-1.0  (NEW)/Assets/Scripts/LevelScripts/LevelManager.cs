using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject currentCheckpoint;
    private MovementController player;
    public static LevelManager instance;
    public AnimationClip exitLevel;
    public Animator anim;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<MovementController>();
        Cursor.visible = false;
    }

    public void ExitLevel()
    {
        anim.SetBool("ExitLevel", true);
        StartCoroutine(TransitionTime(exitLevel.length));
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
