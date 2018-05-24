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
    public int health;
    public int maxHealth =10;
    public int potions;
    public int maxPotions= 3;

    public VidaManager vidaManager;
    public PotionsManager potionsManager;
    public Ataque ataque;
    public MovementController movement;
    [HideInInspector]
    public GameObject Player;
    //Transform PlayerTr;
    public BoxCollider2D sword;
    
    //public int VidaInicio;

    //private Scene currentScene;
    
    
    
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
        vidaManager = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
        potionsManager = GameObject.Find("HUDCanvas").transform.GetChild(1).GetComponent<PotionsManager>();
        ataque = GameObject.Find("Player").GetComponent<Ataque>();
        movement = GameObject.Find("Player").GetComponent<MovementController>();
        //currentScene = SceneManager.GetActiveScene();
    }

    //void Update()
    //{
    //    SceneController(currentScene);
       
    //}
    

    //void SceneController(Scene currentScene)
    //{
    //    if(currentScene != SceneManager.GetActiveScene())
    //    {
    //        LoadValuesScene();
    //        VidaManager.VidaActual = VidaPlayer;
    //        VidaManager.VidaInicio = VidaInicio;
    //        PotionsManager.CurrentPotions = NumPociones;
    //        currentScene = SceneManager.GetActiveScene();
    //    }
    //}



    //public void LoadValuesScene()
    //{
    //    sword = GameObject.Find("Player").transform.GetChild(1).GetComponent<BoxCollider2D>();
    //    vidaManager = GameObject.Find("HUDCanvas").transform.GetChild(0).GetComponent<VidaManager>();
    //    potionsManager = GameObject.Find("HUDCanvas").transform.GetChild(1).GetComponent<PotionsManager>();
    //    ataque = GameObject.Find("Player").transform.GetChild(1).GetComponent<Ataque>();
    //    movement = GameObject.Find("Player").GetComponent<MovementController>();
    //}
   


    public int UpdatePotions(int updatedPotions)
    {
        potions = updatedPotions;
        return potions;
    }

    public int MaxHealth(int addMaxHealth)
    {
        maxHealth += addMaxHealth;
        return maxHealth;
    }

    public int UpdateHealth(int updatedHealth)
    {
        health = updatedHealth;
        return health;
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
        MaxHealth(2);
        health = maxHealth;
        Debug.Log("hay hola");
    }
    public void Concentracion()
    {

    }

}
