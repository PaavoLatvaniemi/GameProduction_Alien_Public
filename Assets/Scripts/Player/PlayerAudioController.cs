using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] float footstepNoiseMaxLoudness = 10.0f;
    Rigidbody rb;
    FirstPersonAIO firstPersonAIO;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPersonAIO = GetComponent<FirstPersonAIO>();
        StartCoroutine(FootStepNoise());
    }

    private IEnumerator FootStepNoise()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;
            DoMovementNoise();
            
        }
    }

    private void DoMovementNoise()
    {
        if (rb.velocity.magnitude > 2.2f)
        {
            if (firstPersonAIO.isCrouching) return;

            NoiseMakerSystem.MakeNoise(transform.position, footstepNoiseMaxLoudness * Mathf.Pow(rb.velocity.magnitude/7f, 2f), true);
        }
    }
}

