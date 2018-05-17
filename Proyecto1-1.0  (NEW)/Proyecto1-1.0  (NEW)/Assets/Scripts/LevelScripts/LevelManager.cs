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
    public AnimationClip enterLevel;
    private Animator animTransition;
    private Animator animPlayer;
    bool entering=false;


    // Use this for initialization
    void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<MovementController>();
        animTransition = GameObject.Find("LevelTransition").GetComponent<Animator>();
        animPlayer = GameObject.Find("Player").GetComponent<Animator>();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        StartCoroutine(TransitionEnterTime(enterLevel.length-0.3f));
    }
    private void Update()
    {
        if (entering)
        {
            animPlayer.SetBool("Idle", false);
            player.transform.Translate(new Vector3(1, 0) * Time.deltaTime * player.speed * 0.5f);
        }
    }

    public void ExitLevel()
    {
        animTransition.SetBool("ExitLevel", true);
        StartCoroutine(TransitionExitTime(exitLevel.length));
    }

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }

    IEnumerator TransitionExitTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)% SceneManager.sceneCountInBuildSettings);
    }

    IEnumerator TransitionEnterTime(float time)
    {
        //animPlayer.SetBool("Idle", false);
        entering = true;
        yield return new WaitForSeconds(time);
        entering = false;
        //animPlayer.SetBool("Idle", true);
    }
}
