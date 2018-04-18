using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour {

    private Elevator speed;
    public Transform elevator;
    public Transform refPoint;
    private bool pressed = false;


    private void Start()
    {
        speed = GameObject.Find("ElevatorPlatform").GetComponent<Elevator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && refPoint.position.y != elevator.position.y)
        {
            MoveElevator();
            if (elevator.transform.position.y == refPoint.transform.position.y)
                pressed = false;
        }
    }

    void MoveElevator()
    {
        elevator.position = Vector3.MoveTowards(elevator.position, new Vector3(elevator.position.x, refPoint.position.y, elevator.position.z), speed.speed * Time.deltaTime);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sword")
            pressed = true;

    }
}
