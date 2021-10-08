using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseMakerSystem
{
    private static List<HearingSensor> hearingSensors = new List<HearingSensor>();

    public static void MakeNoise(Vector3 noisePos, float hearingDistance, bool fromPlayer)
    {
        foreach (var sensor in hearingSensors)
        {
            Vector3 sensorPos = sensor.transform.position;

            if(Vector3.Distance(noisePos, sensorPos) <= hearingDistance)
                sensor.ActivateSensor(noisePos, fromPlayer);
        }
    }

    public static void LinkSensor(HearingSensor sensor) => hearingSensors.Add(sensor);
    public static void UnlinkSensor(HearingSensor sensor) => hearingSensors.Remove(sensor);
}
