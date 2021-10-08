using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class RecordMicrophone : MonoBehaviour
{
    [SerializeField] bool useMicrophone = true;
    [SerializeField] float loudnessThreshold;
    [SerializeField] float hearingRangeMultiplier;
    [SerializeField] Transform player;

    private int minFreq;
    private int maxFreq;

    private AudioSource audioSource;

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;


    void Start()
    {
        clipSampleData = new float[sampleDataLength];

        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not connected!");
            useMicrophone = false;
        }
        if (!useMicrophone) return;

        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

        if (minFreq == 0 && maxFreq == 0)
            maxFreq = 44100;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 20, maxFreq);
        audioSource.Play();
    }

    void Update()
    {

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
                clipLoudness += Mathf.Abs(sample);

            clipLoudness /= sampleDataLength;
            if (clipLoudness > loudnessThreshold) 
                NoiseMakerSystem.MakeNoise(player.position, hearingRangeMultiplier * clipLoudness * 100f, true);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, hearingRangeMultiplier * clipLoudness * 100f);
    }
}
