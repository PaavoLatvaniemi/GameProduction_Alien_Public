using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    [SerializeField] float noiseHearingDistance;

    [ContextMenu("Make Noise")]
    public void MakeNoise()
    {
        NoiseMakerSystem.MakeNoise(transform.position, noiseHearingDistance, false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, noiseHearingDistance);
    }
}
