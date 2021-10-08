using System;
using System.Collections.Generic;
using UnityEngine;

public class HearingSensor : MonoBehaviour
{
    public event Action<Vector3, bool> OnSensorActivated;

    private void OnEnable()
    {
        NoiseMakerSystem.LinkSensor(this);
    }

    private void OnDisable()
    {
        NoiseMakerSystem.UnlinkSensor(this);
    }

    public void ActivateSensor(Vector3 noisePos, bool fromPlayer)
    {
        //Debug.Log($"<color=orange> Sensor hearing noise from: {noisePos}</color>");
        OnSensorActivated?.Invoke(noisePos, fromPlayer);
    }

    
}
