using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    public float time;


    private float shakeTimer;
    private float shakeForce;
    public float shakePower;
    public float shakeDuration;


    private Transform player;
    private Vector2 velocidad;

    //public Enemy enm;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidad.x, time);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocidad.y, time);

        transform.position = new Vector3(Mathf.Clamp(posX,xMin,xMax), Mathf.Clamp(posY,yMin,yMax), transform.position.z);

        

    }
    /* Esta parte del codigo depende de la existencia de enemigos 
    private void Update()
    {
        if(shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeForce;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);


            shakeTimer = shakeTimer - Time.deltaTime;
            Debug.Log("He colisionado");
        }

        if (enm.HaColisionado == true)
        {
            ShakeCamera(shakePower, shakeDuration);
            enm.HaColisionado = false;
        }
    }*/
    public void ShakeCamera(float shakePower,float shakeDuration)
    {
        shakeForce = shakePower;
        shakeTimer = shakeDuration;
    }


}

