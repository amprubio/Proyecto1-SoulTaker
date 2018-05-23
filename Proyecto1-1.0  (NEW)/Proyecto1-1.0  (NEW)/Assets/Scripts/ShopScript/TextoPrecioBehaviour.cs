using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextoPrecioBehaviour : MonoBehaviour {
	public Text price;
	private int pri;


	void Start () {
		pri= GameObject.FindGameObjectWithTag("Spawn").transform.GetChild(0).GetComponent<BoosterBehaviour>().amountSouls;
			Debug.Log ("aa");
			price=GetComponent<Text> ();
			Initial (price);
		}
	void Initial(Text t)
	{
		Debug.Log ("ayuda");
		t = GetComponent<Text> ();
		Debug.Log ("miaun't");
		t.text= ("0");
	}

	void Update(){
		Debug.Log ("pf");
		price.text = pri.ToString ();
	}
}

