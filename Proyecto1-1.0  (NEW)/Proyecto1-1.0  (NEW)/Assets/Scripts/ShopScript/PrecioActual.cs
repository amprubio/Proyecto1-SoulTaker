using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PrecioActual : MonoBehaviour {
	public Text txt;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject == GameObject.Find (Name ())) {
			txt = GetComponent<Text> ();
			txt.text = GetComponent<BoosterBehaviour> ().amountSouls.ToString();
		}
	}
	
	public string Name ()
	{
		string name=null;

		switch (name) {
		case "Ladron(Clone)":
			return"Ladron(Clone)";
			break;

		case "BebidaEnergetica(Clone)":
			return "BebidaEnergetica(Clone)";
			break;

		case "Becario(Clone)":
			return "Becario(Clone)";
			break;

		case "Mandoble(Clone)":
			return "Mandoble(Clone)";
			break; 

		case "FiloLigero(Clone)":
			return "FiloLigero(Clone)";
			break;

		case "PiedraDeAfilar(Clone)":
			return "PiedraDeAfilar(Clone)";
			break;

		case "Kebab(Clone)":
			return "Kebab(Clone)";
			break;

		case "Focus(Clone)":
			return "Focus(Clone)";
			break;
		default:
			return null;
			break;
		}

	}
}
