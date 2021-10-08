using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockIndicator : MonoBehaviour
{
    [SerializeField] Material unlockedIndicatorLight;
    [SerializeField] Material lockedIndicatorLight;

    MeshRenderer indicatorLight;
    DoorBase door;

    private void Awake()
    {
        indicatorLight = GetComponent<MeshRenderer>();
        door = GetComponentInParent<DoorBase>();
        door.OnLockStateChanged += ChangeIndicatorState;
        ChangeIndicatorState(door.locked);
    }

    private void OnDestroy()
    {
        door.OnLockStateChanged -= ChangeIndicatorState;
    }

    void ChangeIndicatorState(bool state)
    {
        if (state)
            indicatorLight.material = lockedIndicatorLight;
        else
            indicatorLight.material = unlockedIndicatorLight;
    }
}
