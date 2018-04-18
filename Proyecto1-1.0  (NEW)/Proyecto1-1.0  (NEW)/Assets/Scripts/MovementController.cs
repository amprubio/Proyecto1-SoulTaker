using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 7.0f;
    public float fall = 2.0f;
    public float jumpImpulse = 2.0f, jumpForce= 2.0f;
    public float countDown = 0.3f;
	[Header("Contador")]
	public int countGranade=7;
    bool Onfloor = false, jumpKeyHeld = false;
    public SpriteRenderer Player;
	public GameObject granada;

    [Header("Flip de los colliders del player")]
    public Collider2D FeetCol;
    public Collider2D SwordCol;
    private Collider2D BodyCol;

    

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Player = GetComponent<SpriteRenderer>();
        BodyCol = gameObject.GetComponent<CapsuleCollider2D>();
        
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
            BodyCol.offset = new Vector2(-0.1f,0.05f);
            FeetCol.offset = new Vector2(-0.15f,-0.5f);
            SwordCol.offset = new Vector2(-0.85f,0);
        }
        else if (axisX > 0)
        {
            Player.flipX = false;
            BodyCol.offset = new Vector2(0.1f, 0.05f);
            FeetCol.offset = new Vector2(0.15f, -0.5f);
            SwordCol.offset = new Vector2(0.85f, 0);

        }

		if (InputManager.RBButton ()) {
			if (countGranade != 0)
				Instantiate (granada, transform.position + new Vector3 (0f, 1f, 0f), Quaternion.identity);
			else
				Invoke ("Counter", 18000);
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

	private void Counter(ref int countGranade)
	{
		countGranade++;
	}


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "DynamicPlatform")
        {
            Onfloor = true;
            transform.parent = other.transform;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "DynamicPlatform")
        {
            Onfloor = false;
            transform.parent = null;
        }

    }
    
}