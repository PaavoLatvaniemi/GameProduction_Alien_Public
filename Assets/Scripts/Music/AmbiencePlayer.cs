using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
    AudioSource audioSource;
    float initVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initVolume = audioSource.volume;
    }

    public void FadeIn(float duration)
    {
        audioSource.volume = 0f;
        audioSource.Play();
        StartCoroutine(FadeAudio(0f, initVolume, duration));
    }

    public void FadeOut(float duration)
    {
        audioSource.volume = initVolume;
        StartCoroutine(FadeAudio(initVolume, 0f, duration));
    }

    IEnumerator FadeAudio(float startVolume, float endVolume, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            audioSource.volume = Mathf.Lerp(startVolume, endVolume, normalizedTime);

            yield return null;
        }
        audioSource.volume = endVolume;
        if (audioSource.volume == 0f) audioSource.Stop();
    }
}
