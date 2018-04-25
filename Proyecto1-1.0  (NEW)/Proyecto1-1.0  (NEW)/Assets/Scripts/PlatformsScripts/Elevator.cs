using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public float speed;
    public Transform top;
    public Transform bottom;
    [SerializeField]
    private bool active = false;
    [SerializeField]
    private bool movingUp = false;
    [SerializeField]
    private bool movingDown = false;


    // Update is called once per frame
    void Update ()
    {
        MoveUp();
        MoveDown();
    }

    void MoveUp()
    {
        if (active && !movingDown && top.position.y > transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, top.position.y, transform.position.z), speed * Time.deltaTime);
            movingUp = true;
            if (transform.position.y == top.transform.position.y)
            {
                active = false;
                movingUp = false;
            }
        }
    }

    void MoveDown()
    {
        if (active && !movingUp && bottom.position.y < transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, bottom.position.y, transform.position.z), speed * Time.deltaTime);
            movingDown = true;
            if (transform.position.y == bottom.transform.position.y)
            {
                active = false;
                movingDown = false;
            }

        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            active = true;
        }
    }
}

