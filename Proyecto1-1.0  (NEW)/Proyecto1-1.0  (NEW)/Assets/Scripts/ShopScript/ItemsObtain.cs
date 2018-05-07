using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsObtain : MonoBehaviour {
	//los objetos con tag de enemigo 

	[Header("Atributos del objeto")]
	[HideInInspector]
	public bool obtained=false;
	private float CurrentHealth;
	public float souls;
	public float darkness;
	private Souls giveSouls;
	private Darkness giveDarkness;


	void Start()
	{
		SetInitialReferences();
	}

	public void OnDestroy()
	{
		//GameManager.instance.SubsDarkness(darkness);
		GameManager.instance.SubsSouls(souls);
	}


	void SetInitialReferences()
	{
		CurrentHealth = 1;
	}

	public void Obtain (float i)
	{
		Debug.Log ("mira un objeto");
		while (GameManager.instance.souls - souls >= 0) {
			CurrentHealth = CurrentHealth - i;
			if (CurrentHealth <= 0)
				obtained = true;
				Destroy (this.gameObject);
			OnDestroy ();

		}
	}
}
