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
	

    void SetInitialReferences()
    {
        soulsCount = GameObject.Find("SoulsCount").GetComponent<Text>();
    }

    void InitialSouls()
    {
        if (soulsCount != null)
            soulsCount.text = ("" + souls);
    }

     public void AddSouls(float amountSouls)
     {
        souls += amountSouls;
        soulsCount.text = ("" + souls);
     } 
}
