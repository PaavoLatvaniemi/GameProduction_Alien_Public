using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light flashlight;
    AudioSource AudioSource;
    bool isOn = true;

    void Awake()
    {
        flashlight = GetComponent<Light>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
            AudioSource.Play();
        }
    }
}
