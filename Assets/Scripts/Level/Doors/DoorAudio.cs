using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorAudio : MonoBehaviour
{
    [SerializeField] AudioClip openClip;
    [SerializeField] AudioClip closeClip;
    [SerializeField] AudioClip lockedClip;

    AudioSource audioSource;
    DoorBase door;
    private void Awake()
    {
        door = GetComponent<DoorBase>();
        audioSource = GetComponent<AudioSource>();
        door.OnDoorStateChanged += PlayDoorAudio;
    }
    private void OnDestroy()
    {
        door.OnDoorStateChanged -= PlayDoorAudio;
    }

    void PlayDoorAudio(bool openState)
    {
        if (door.locked)
        {
            if (lockedClip == null) return;
            audioSource.clip = lockedClip;
            audioSource.Play();
            return;
        }

        if (openState)
            audioSource.clip = openClip;
        else
            audioSource.clip = closeClip;

        audioSource.Play();
    }
}
