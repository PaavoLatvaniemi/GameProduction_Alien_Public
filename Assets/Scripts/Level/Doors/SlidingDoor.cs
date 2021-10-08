using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingDoor : DoorBase
{
    [SerializeField] Vector3 openPosition;
    [SerializeField] float doorSpeed;

    Vector3 initPos;
    bool animationDone;

    private void Awake()
    {
        initPos = transform.position;
    }

    public override void ToggleDoorState()
    {
        base.ToggleDoorState();
        animationDone = false;
    }

    [ContextMenu("OpenDoor")]
    public override void OpenDoor()
    {
        animationDone = false;
        base.OpenDoor();
    }
    [ContextMenu("CloseDoor")]
    public override void CloseDoor()
    {
        base.CloseDoor();
        animationDone = false;
    }

    private void Update()
    {
        if (animationDone) return;

        if (open)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
            if (transform.position == openPosition) animationDone = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos, doorSpeed * Time.deltaTime);
            if (transform.position == initPos) animationDone = true;
        }
    }
}
