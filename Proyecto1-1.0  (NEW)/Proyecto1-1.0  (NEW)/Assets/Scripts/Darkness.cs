using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour {

    private float darkness = 0f;
    private Text darknessCount;

    
    void Start ()
    {
        SetInitialReferences();
        InitialDarkness();
    }
    void InitialDarkness()
    {
        
            darknessCount.text = ("0");
    }
    
    void SetInitialReferences()
    {
        darknessCount = GameObject.Find("DarknessCount").GetComponent<Text>();
    }

    private void Update()
    {
        darknessCount.text = GameManager.instance.darkness.ToString();
    }


}
