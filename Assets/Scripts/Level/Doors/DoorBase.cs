using System;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour
{
    [SerializeField] protected bool _open;
    [SerializeField] protected bool _locked;
    public bool open => _open;
    public bool locked => _locked;

    public event Action<bool> OnDoorStateChanged;
    public event Action<bool> OnLockStateChanged;

    protected virtual void Start()
    {
        if (_locked) LockDoor();
        else UnlockDoor();
    }

    public virtual void ToggleDoorState()
    {
        if (_open) ChangeDoorState(false);
        else ChangeDoorState(true);
    }

    public virtual void ToggleLockedState()
    {
        if (_locked) ChangeLockedState(false);
        else ChangeLockedState(true);
    }
    public virtual void OpenDoor() => ChangeDoorState(true);
    public virtual void CloseDoor() => ChangeDoorState(false);
    public void LockDoor() => ChangeLockedState(true);
    public void UnlockDoor() => ChangeLockedState(false);

    protected virtual void ChangeDoorState(bool state)
    {
        OnDoorStateChanged?.Invoke(state);
        if (_open == state) return;
        if (!_open && _locked) return;
        _open = state;
    }

    protected virtual void ChangeLockedState(bool state)
    {
        OnLockStateChanged?.Invoke(state);
        if (_locked == state) return;
        _locked = state;
    }
}
