using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour {
    private float darkness = 0f;
    private Text darknessCount;
    private GameObject enemy;
    private EnemyProperties enemyDarkness;

    // Use this for initialization
    void Start ()
    {
        SetInitialReferences();
        InitialDarkness();
    }
	
	// Update is called once per frame
	void Update ()
    {
        AddDarkness();
	}

    void InitialDarkness()
    {
        if (darknessCount != null)
            darknessCount.text = ("" + darkness);
    }
    
    void SetInitialReferences()
    {
        darknessCount = GameObject.Find("DarknessCount").GetComponent<Text>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyDarkness = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyProperties>();
    }

    void AddDarkness()
    {
        if (enemy == null)
            darkness += enemyDarkness.souls;

        darknessCount.text = ("" + darkness);
    }
}
