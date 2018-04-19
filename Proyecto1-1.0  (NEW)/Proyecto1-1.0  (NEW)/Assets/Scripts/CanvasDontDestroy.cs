﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDontDestroy : MonoBehaviour {

    public GameObject instance;

    void Awake()
    {

        if (instance == null)
        {

            instance = this.gameObject;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            Destroy(this.gameObject);
        }
    }
}