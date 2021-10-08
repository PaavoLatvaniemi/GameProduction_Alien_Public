using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHearingController : MonoBehaviour
{
    [SerializeField] HearingSensor hearingSensor;
    public Vector3 LastHeardNoisePos { get; private set; }

    private bool heardNoise;
    private bool heardNoiseFromPlayer;

    private void OnEnable()
    {
        GetComponent<StateMachine>().OnStateChanged += ResetHearing;
        hearingSensor.OnSensorActivated += Hear;
    }

    private void OnDisable()
    {
        GetComponent<StateMachine>().OnStateChanged -= ResetHearing;
        hearingSensor.OnSensorActivated -= Hear;
    }

    private void Hear(Vector3 noisePos, bool fromPlayer)
    {
        LastHeardNoisePos = noisePos;
        heardNoise = true;
        heardNoiseFromPlayer = fromPlayer;
    }

    private void ResetHearing() 
    {
        heardNoise = false;
    }

    public bool HeardNoise()
    {
        if (heardNoise)
        {
            heardNoise = false;
            return true;
        }
        return false;
    }

    public bool HeardNoiseFromPlayer()
    {
        if (heardNoiseFromPlayer)
        {
            heardNoiseFromPlayer = false;
            return true;
        }
        return false;
    }
}
