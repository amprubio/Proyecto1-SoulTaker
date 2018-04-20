using UnityEngine;

/// <summary>
/// Gestor del juego (singleton simplificado). Controlará el estado del juego
/// y tendrá métodos llamados desde los distintos objetos que lo hacen avanzar.
/// Debe haber una única instancia. 
/// </summary>
public class GameManager : MonoBehaviour
{


    public static GameManager instance = null;
    [HideInInspector]
    public float darkness;
    [HideInInspector]
    public float souls;

    ObjectManager objMan;

    


    void Awake()
    {

        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            Destroy(this.gameObject);
        }
    }

    public void AddSouls(float amountSouls)
    {
        souls += amountSouls;

    }
    public void AddDarkness(float amountDarkness)
    {
        darkness += amountDarkness;

    }

    public void SubsSouls(float amountSouls)
    {
        souls -= amountSouls;
    }

    public void SubsDarkness(float amountDarkness)
    {
        darkness -= amountDarkness;
    }

    public void changeStats()
    {
        switch(objMan.objectsArr[objMan.tmp].objeto.name)
        {
            case "ladron":

                break;
            case "kebab":
                break;
            case "piedradeafilar":
                break;
            case "bebida":
                break;
            case "becario":
                break;
            case "filoligero":
                break;
            case "mandoble":
                break;
            case "concentraccion":
                break;
        }
    }


}
