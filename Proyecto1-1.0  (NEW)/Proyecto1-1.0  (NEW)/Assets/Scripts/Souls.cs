using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls : MonoBehaviour {
    private float souls = 0f;
    private Text soulsCount;

	// Use this for initialization
	void Start () 
    {
        SetInitialReferences();
        InitialSouls();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetInitialReferences()
    {
        soulsCount = GameObject.Find("SoulsCount").GetComponent<Text>();
    }

    void InitialSouls()
    {
        if (soulsCount != null)
            soulsCount.text = ("" + souls);
    }
}
