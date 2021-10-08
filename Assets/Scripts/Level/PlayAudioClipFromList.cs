using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PlayAudioClipFromList : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip()
    {
        AudioClip clip = RandomUtils<AudioClip>.RandomFromArray(clips);
        audioSource.PlayOneShot(clip);
    }
}
