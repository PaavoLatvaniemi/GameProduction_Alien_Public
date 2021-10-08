using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnTrigger : MonoBehaviour
{
    [SerializeField] DoorBase door;
    [SerializeField] float secondsOpen;
    Timer timer;
    bool inTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Alien"))
        {
            inTrigger = true;
            door.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Alien"))
        {
            timer = TimerFactory.CreateTimer(secondsOpen);
            inTrigger = false;
        }
    }

    private void Update()
    {
       if(door.open && !inTrigger)
        {
            timer.Tick();
            if (timer.Finished()) door.CloseDoor();
        }
    }
}
