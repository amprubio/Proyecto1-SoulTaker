using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada_Movement : MonoBehaviour {
public float distance=10.0f;
public float angulo = 45.0f;
public float gravedad=9.8f;
public float speed=1;
public GameObject prefabExplosion;
public Transform granada;
public SpriteRenderer Avatar;
private bool flipped;
void Awake (){
	//igualamos nuestro transform al transform de la granada ya que el avatar será el punto inicial de referencia
	float axisX = GameInputManager.MainHorizontal ();
	if (axisX<0) {
		flipped = true;
	}
	if (axisX>0) {
		flipped = false;
	}
	StartCoroutine (Lanzamiento ()); //llamada al metodo mediante corrutinas
}
public IEnumerator Lanzamiento(){
	Avatar = GetComponent<SpriteRenderer> ();
	Debug.Log ("Dentro de la corrutina");
	Debug.Log ("Más Dentro de la corrutina");
	//retardo corto antes del lanzamiento
	//yield return new WaitForSecondsRealtime (0); //revisar segun la animacion del avatar y el spawneo
	//movimiento del proyectil a la posicion de lanzamiento + offset si es necesario (revisar)
	//calculo de distancia al enemigo
	Debug.Log ("jaja si Dentro de la corrutina");
	float s= Vector3.Distance(granada.position, granada.position+ new Vector3(distance,0f,0f));
	//velocidad inicial
	float velocidad_inicial=s/(Mathf.Sin(2*angulo*Mathf.Deg2Rad)/gravedad);
	//componentes x e y
	float velocidad_X= Mathf.Sqrt(velocidad_inicial)*Mathf.Cos(angulo*Mathf.Deg2Rad);
	float velocidad_Y= Mathf.Sqrt(velocidad_inicial)*Mathf.Sin(angulo*Mathf.Deg2Rad);
	// calculo de tiempo
	float t= s/velocidad_X;
	//movimiento de parabola en sí
	float time=0;
	//Pon aqui un if esta girado
	Debug.Log ("jaja si antes del if");

	if (flipped) {
		velocidad_X = -velocidad_X;
	}
	while (time < t) {

		granada.Translate (velocidad_X * Time.deltaTime, (velocidad_Y - (gravedad * time)) * Time.deltaTime, 0); 
		time += Time.deltaTime;
		yield return null;
	} 
	Instantiate (prefabExplosion, granada.transform.position,  Quaternion.identity);
	Destroy (this.gameObject,0f);
	Destroy (prefabExplosion.gameObject,1f);


}
	}


