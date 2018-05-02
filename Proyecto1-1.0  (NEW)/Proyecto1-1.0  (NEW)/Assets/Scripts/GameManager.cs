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
    public float perSouls = 1;
    public float perDarkness = 1;

    public Vida vida;
    public Ataque ataque;
    public MovementController movement;
    [HideInInspector]
    public GameObject Player;
    Transform PlayerTr;
    public BoxCollider2D sword;
    
    

    


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

    private void Start()
    {
        Player = GameObject.Find("Player");
        sword = Player.transform.GetChild(1).GetComponent<BoxCollider2D>();
        
    }

    

    public void AddSouls(float amountSouls)
    {
        souls += amountSouls*perSouls;

    }
    public void AddDarkness(float amountDarkness)
    {
        darkness += amountDarkness * perDarkness;

    }

    public void SubsSouls(float amountSouls)
    {
        souls -= amountSouls;
    }

    public void SubsDarkness(float amountDarkness)
    {
        darkness -= amountDarkness;
    }

    public void ChangeStats(string nameMethod)
    {
        Debug.Log("ayjoder");
        switch(nameMethod)
        {
            case "Ladron(Clone)":
                Ladron();
                break;

            case "BebidaEnergetica(Clone)":
                BebidaEnergetica();
                break;

            case "Becario(Clone)":
                Becario();
                break;

            case "Mandoble(Clone)":
                Mandoble();
                break; 

            case "FiloLigero(Clone)":
                FiloLigero();
                break;

            case "PiedraDeAfilar(Clone)":
                PiedraDeAfilar();
                break;

            case "Kebab(Clone)":
                Kebab();
                break;

            case "Concentracion(Clone)":
                Concentracion();
                break;

            

        }

    }


    public void Ladron()
    {
        perSouls = 1.2f;
        Debug.Log("hay hola");
    }
    public void BebidaEnergetica()
    {
        movement.speed = movement.speed * 1.2f;
        Debug.Log("hay hola");
    }
    public void Becario()
    {
        perDarkness = 1.2f;
        Debug.Log("hay hola");
    }
    public void Mandoble()
    {
        sword.offset = new Vector2(1f, sword.offset.y);
        sword.size = new Vector2(1f, sword.size.y);
        Debug.Log("hay hola");
    }
    public void FiloLigero()
    {
        ataque.tRetardo = ataque.tRetardo * 0.4f;
        Debug.Log("hay hola");
    }
    public void PiedraDeAfilar()
    {
        ataque.DañoAtaque = ataque.DañoAtaque * 1.25f;
        Debug.Log("hay hola");
    }
    public void Kebab()
    {
        vida.AniadeCorazon();
        Debug.Log("hay hola");
    }
    public void Concentracion()
    {

    }

}
