using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoPrecio : MonoBehaviour {

	private Text price;


	void Start ()
	{
		SetInitialReferences();
		Initial();
	}
	void SetInitialReferences()
	{
		price= GetComponent<Text>();
	}
	void Initial()
	{
		price.text = ("0");
	}

}
