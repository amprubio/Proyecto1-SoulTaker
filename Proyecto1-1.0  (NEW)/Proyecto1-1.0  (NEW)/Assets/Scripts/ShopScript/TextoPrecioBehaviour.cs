using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextoPrecioBehaviour : MonoBehaviour {
	public Text []price= new Text[3];
	private int[] pri= new int[3];

	// Use this for initialization
	void Start () {
		for (int i =0;i>=pri.Length;i++){
			pri[i] = GameObject.Find("SpawnPoint " +"("+i+")").transform.GetChild(0).GetComponent<BoosterBehaviour>().amountSouls;
			Initial (price [i]);
		}
	}
	void Initial(Text t)
	{
		t = GetComponent<Text> ();
		Debug.Log ("miaun't");
		t.text= ("0");
	}
	void ReWrite(Text t, int i){
		t.text = i.ToString ();
	}
	// Update is called once per frame
	void Update () {
		for(int i =0;i>= price.Length;i++)
			ReWrite (price[i],pri[i]);
	}
	}

