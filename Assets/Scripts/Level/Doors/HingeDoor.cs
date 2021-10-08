using System;
using System.Collections.Generic;
using UnityEngine;

public class HingeDoor : DoorBase
{
    [SerializeField] float doorOpenAngle = 90f;
    [SerializeField] float doorCloseAngle = 0f;
    [SerializeField] float smooth = 2f;

    bool animationDone;
    
    [ContextMenu("ToggleDoorState")]
    public override void ToggleDoorState()
    {
        base.ToggleDoorState();
        animationDone = false;
    }
    [ContextMenu("ToggleLockedState")]
    public override void ToggleLockedState()
    {
        base.ToggleLockedState();
    }

    protected override void ChangeDoorState(bool state)
    {
        base.ChangeDoorState(state);
        animationDone = false;
    }

    void Update()
    {
        if (animationDone) return;

        Quaternion targetRotation;
        if (_open) targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
        else targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);

        if (_open)
        {
            if (_locked)
            {
                animationDone = true;
                return;
            }
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            if (transform.localRotation == targetRotation) animationDone = true;
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            if (transform.localRotation == targetRotation) animationDone = true;
        }
    }
}
