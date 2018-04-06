//using UnityEngine;

///// <summary>
///// Gestor del juego (singleton simplificado). Controlará el estado del juego
///// y tendrá métodos llamados desde los distintos objetos que lo hacen avanzar.
///// Debe haber una única instancia. 
///// </summary>
//public class GameManager : MonoBehaviour {

	
//	public static GameManager instance = null;



//    public float darkness;
//    public float souls;

	
//	void Awake() {
		
//		if (instance == null) {
			
//			instance = this;
			
//			DontDestroyOnLoad(this.gameObject);
//		}
//		else {
			
//			Destroy(this.gameObject);
//		}
//	}

//    public void AddSouls(float amountSouls)
//    {
//        souls += amountSouls;
        
//    }
//    public void AddDarkness(float amountDarkness)
//    {
//        darkness += amountDarkness;
        
//    }


//}
