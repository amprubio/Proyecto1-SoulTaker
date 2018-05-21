using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    public static GameManager instance = null;
    [HideInInspector]
    public float darkness;
    [HideInInspector]
    public float souls;
    public float perSouls = 1;
    public float perDarkness = 1;

    public VidaManager vidaManagerGM;
    public PotionsManager potionsManagerGM;
    public Ataque ataque;
    public MovementController movement;
    [HideInInspector]
    public GameObject Player;
    Transform PlayerTr;
    public BoxCollider2D sword;
    public int VidaPlayer;
    public int NumPociones;
    public int VidaInicio;

    private Scene currentScene;
    
    
    
    void Awake()
    {

        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {

            DestroyImmediate(this.gameObject);
        }
    }

    private void Start()
    {
        sword = GameObject.Find("Player").transform.GetChild(1).GetComponent<BoxCollider2D>(); 
        vidaManagerGM = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
        potionsManagerGM = GameObject.Find("HUDCanvas").transform.GetChild(1).GetComponent<PotionsManager>();
        ataque = GameObject.Find("Player").GetComponent<Ataque>();
        movement = GameObject.Find("Player").GetComponent<MovementController>();
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        SceneController(currentScene);
       
    }





    void SceneController(Scene currentScene)
    {
        if(currentScene != SceneManager.GetActiveScene())
        {
            LoadValuesScene();
            VidaManager.VidaActual = VidaPlayer;
            VidaManager.VidaInicio = VidaInicio;
            PotionsManager.CurrentPotions = NumPociones;
            currentScene = SceneManager.GetActiveScene();
        }
    }



    public void LoadValuesScene()
    {
        sword = GameObject.Find("Player").transform.GetChild(1).GetComponent<BoxCollider2D>();
        vidaManagerGM = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
        potionsManagerGM = GameObject.Find("HUDCanvas").transform.GetChild(1).GetComponent<PotionsManager>();
        ataque = GameObject.Find("Player").transform.GetChild(1).GetComponent<Ataque>();
        movement = GameObject.Find("Player").GetComponent<MovementController>();
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

            case "Focus(Clone)":
                Concentracion();
                break;

            

        }

    }

    // Objetos
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
        vidaManagerGM.AniadeCorazon();
        Debug.Log("hay hola");
    }
    public void Concentracion()
    {

    }

}
