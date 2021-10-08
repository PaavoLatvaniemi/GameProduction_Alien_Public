using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEffect : MonoBehaviour
{
    [SerializeField] Material lightOn;
    [SerializeField] Material lightOff;
    [SerializeField] AudioSource audioSource;
    [SerializeField] MeshRenderer lightMesh;
    [SerializeField] float blinkInterval = 1f;

    bool isOn;

    private void Start()
    {
        InvokeRepeating("BlinkAlarm", blinkInterval, blinkInterval);
    }

    void BlinkAlarm()
    {
        isOn = !isOn;
        if(audioSource != null && isOn)
            audioSource.Play();

        if (isOn) lightMesh.material = lightOn;
        else lightMesh.material = lightOff;
    }
}
