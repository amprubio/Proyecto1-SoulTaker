using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float fall;
    bool Onfloor = false;
    SpriteRenderer Player;
    

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Player = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        //Rotation
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        // Movement
        float axisX = InputManager.MainHorizontal();
        transform.Translate(new Vector3(axisX, 0) * Time.deltaTime * speed);
        if (axisX < 0)
        {
            Player.flipX = true;
        }
        else if (axisX > 0)
        {
            Player.flipX = false;
        }
        // Jump
        //float timer = 0;

        if (InputManager.AButton())
        {
            if (Onfloor)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                /*timer = Time.time;
                if (timer > 1f)
                    timer = 1f;*/
            }
        }

         if (GetComponent<Rigidbody2D>().velocity.y < 0)
             GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (fall) * Time.deltaTime;
    }

    void OnTriggerStay2D()
    {     
        Onfloor = true;      
    }
    void OnTriggerExit2D()
    {
        Onfloor = false;
    }

    
}