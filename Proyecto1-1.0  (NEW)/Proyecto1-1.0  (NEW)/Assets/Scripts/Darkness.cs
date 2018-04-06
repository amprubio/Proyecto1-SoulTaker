using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour {
    private float darkness = 0f;
    private Text darknessCount;

    // Use this for initialization
    void Start ()
    {
        SetInitialReferences();
        InitialDarkness();
    }
	

    void InitialDarkness()
    {
        if (darknessCount != null)
            darknessCount.text = ("" + darkness);
    }
    
    void SetInitialReferences()
    {
        darknessCount = GameObject.Find("DarknessCount").GetComponent<Text>();
    }

    public void AddDarkness(float amountDarkness)
    {
        darkness += amountDarkness;
        darknessCount.text = ("" + darkness);
    }


}
