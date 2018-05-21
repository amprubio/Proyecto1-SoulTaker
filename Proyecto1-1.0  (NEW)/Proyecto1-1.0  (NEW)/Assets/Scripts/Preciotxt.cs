using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preciotxt : MonoBehaviour
{

    public Text[] txt = new Text[3];
    [HideInInspector]
    public string name;
    //precio=
    private void Awake()
    {

    }

    void Start()
    {
        SetInitialReferences();
        InitialPrize();
    }
    void SetInitialReferences()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i] = GetComponent<Text>();
        }

    }
    void InitialPrize()
    {
        for (int i = 0; i < txt.Length; i++)
        {

            txt[i].text = "0";
        }
       

    }
    public void Changetext()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            switch (GameManager.instance.name)
            {
                case "Ladron(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "BebidaEnergetica(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "Becario(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "Mandoble(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "FiloLigero(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "PiedraDeAfilar(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "Kebab(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

                case "Concentracion(Clone)":
                    txt[i].text = "" + GetComponent<BoosterBehaviour>().amountSouls;
                    break;

            }

        }
    }
}
