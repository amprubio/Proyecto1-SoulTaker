using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls : MonoBehaviour {

    private float souls = 0f;
    private Text soulsCount;
    private GameObject enemy;
    private EnemyProperties enemySouls;

    // Use this for initialization
    void Start ()
    {
        SetInitialReferences();
        InitialSouls();
    }
	
	// Update is called once per frame
	void Update ()
    {
            AddSouls();
	}

    void SetInitialReferences()
    {
        soulsCount = GameObject.Find("SoulsCount").GetComponent<Text>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemySouls = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyProperties>();
    }

    void InitialSouls()
    {
        if (soulsCount != null)
            soulsCount.text = ("" + souls);
    }

    void AddSouls()
    {
        if (enemy == null)
            souls += enemySouls.souls;

        soulsCount.text = ("" + souls);
    } 
}
