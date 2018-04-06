using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls : MonoBehaviour {

    private float souls = 0f;
    private Text soulsCount;

    
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
        soulsCount.text = ("0");
    }

    private void Update()
    {
        soulsCount.text = GameManager.instance.souls.ToString();
    }
}
