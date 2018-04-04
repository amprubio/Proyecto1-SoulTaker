using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 7.0f;
    public float fall = 2.0f;
    public float jumpImpulse = 2.0f, jumpForce= 2.0f;
    public float countDown = 0.3f;
    bool Onfloor = false, jumpKeyHeld = false;
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
        
        if (InputManager.AButtonDown() && Onfloor)
        {
            jumpKeyHeld = true;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpImpulse, ForceMode2D.Impulse);

        }

        if (InputManager.AButtonUp())
        {
            countDown = 0.3f;
            jumpKeyHeld = false;
        }

        else if (InputManager.AButton())
        {
            
            countDown -= Time.deltaTime;
            if (jumpKeyHeld && countDown > 0f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10 * jumpForce, ForceMode2D.Force);
            }

        }
        
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
             GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (fall) * Time.deltaTime;
    }

    


    public void OnTriggerStay2D()
    {
        Onfloor = true;
    }
    public void OnTriggerExit2D()
    {
        Onfloor = false;
    }
    
}