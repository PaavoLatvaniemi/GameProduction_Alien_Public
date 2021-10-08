using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickableDoor : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void KickDoorDown(float force)
    {
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force);

        if (audioSource != null)
            audioSource.Play();
    }
}
