using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HidingSpot : MonoBehaviour
{
    [SerializeField] Transform _killPosition;
    [SerializeField] DoorBase door;

    public Transform killPosition => _killPosition;
    public bool doorOpen => door.open;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HidingManager.PlayerEnterHiding(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HidingManager.PlayerResetHiding();
        }
    }

    public void OpenHidingSpotDoor() 
    {
        if (door == null) return;
        door.OpenDoor();
    }
}