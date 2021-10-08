using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorButtons : MonoBehaviour
{
    [SerializeField] bool elevatorActive;
    [SerializeField] float elevatorOpenDelay = 2f;
    [SerializeField] Material lightOn;
    [SerializeField] Material lightOff;
    [SerializeField] MeshRenderer[] lights;
    [SerializeField] UnityEvent OnElevatorOpen;

    bool doorsOpen;

    public void ElevatorActive(bool state)
    {
        if (elevatorActive == state) return;

        elevatorActive = state;
        SwitchLightState(state);

    }

    public void OpenElevator()
    {
        if (elevatorActive && !doorsOpen)
        {
            doorsOpen = true;
            Invoke("InvokeOpenElevator", elevatorOpenDelay);
        }
    }

    void SwitchLightState(bool state)
    {
        foreach (var light in lights)
        {
            if (state) light.material = lightOn;
            else light.material = lightOff;
        }
    }

    void InvokeOpenElevator() => OnElevatorOpen.Invoke();
}
