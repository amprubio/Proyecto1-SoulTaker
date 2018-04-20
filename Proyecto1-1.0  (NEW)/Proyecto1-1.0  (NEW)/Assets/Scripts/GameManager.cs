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
    public BoxCollider2D sword;

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

    private void Start()
    {
        sword = GameObject.Find("Sword").GetComponent<BoxCollider2D>();
        
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

    public void changeStats()
    {
        switch(objMan.objectsArr[objMan.tmp].objeto.name)
        {
            case "ladron":
                perSouls = 1.2f;
                break;
            case "kebab":
                vida.AniadeCorazon();
                break;
            case "piedradeafilar":
                ataque.DañoAtaque = ataque.DañoAtaque * 1.25f;
                break;
            case "bebida":
                movement.speed = movement.speed * 1.2f;
                break;
            case "becario":
                perDarkness = 1.2f;
                break;
            case "filoligero":
                ataque.tRetardo = ataque.tRetardo * 0.4f;
                break;
            case "mandoble":
                sword.offset = new Vector2 (1f, sword.offset.y);
                sword.size  = new Vector2(1f, sword.size.y);
                break;
            case "concentraccion":
                break;
        }
    }


}
