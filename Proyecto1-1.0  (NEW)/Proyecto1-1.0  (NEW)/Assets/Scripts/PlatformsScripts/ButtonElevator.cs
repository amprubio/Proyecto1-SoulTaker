using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour {

    private Elevator speed;
    public Transform elevator;
    public Transform refPoint;
    private bool pressed = false;
    private Animator anim;
    private Animator eAnim;


    private void Start()
    {
        speed = GameObject.Find("ElevatorPlatform").GetComponent<Elevator>();
        anim = GetComponent<Animator>();
        eAnim = GameObject.Find("ElevatorPlatform").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && refPoint.position.y != elevator.position.y)
        {
            MoveElevator();
            if (elevator.transform.position.y == refPoint.transform.position.y)
            {
                pressed = false;
            }
        }
        if (refPoint.position.y == elevator.position.y)
        {
            anim.SetBool("ButtonOn", false);
            anim.SetBool("ElevatorOn", false);
        }

        if (!pressed)
        {
            FindObjectOfType<AudioManager>().Stop("ElevatorOn");
            FindObjectOfType<AudioManager>().Play("CrystalOff");
        }
    }

    void MoveElevator()
    {
        elevator.position = Vector3.MoveTowards(elevator.position, new Vector3(elevator.position.x, refPoint.position.y, elevator.position.z), speed.speed * Time.deltaTime);
        anim.SetBool("ElevatorOn", true);
        FindObjectOfType<AudioManager>().Play("ElevatorOn");
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
        {
            FindObjectOfType<AudioManager>().Stop("CrystalOff");
            FindObjectOfType<AudioManager>().Play("CrystalHit");
            pressed = true;
            anim.SetBool("ButtonOn",true);
            
        }
    }
}
