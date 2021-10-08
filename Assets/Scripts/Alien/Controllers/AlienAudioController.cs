using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAudioController : MonoBehaviour
{
    [SerializeField] AlienAudio alienAudio;
    [SerializeField] AudioSource footstepLAudioSource;
    [SerializeField] AudioSource footstepRAudioSource;
    [SerializeField] AudioSource vocalAudioSource;

    public void AnimEventFootstepL(AnimationEvent evt)
    {
        if (evt.animatorClipInfo.weight > 0.5)
            PlayFootstep(footstepLAudioSource);
    }

    public void AnimEventFootstepR(AnimationEvent evt)
    {
        if (evt.animatorClipInfo.weight > 0.5)
            PlayFootstep(footstepRAudioSource);
    }
    void PlayFootstep(AudioSource audioSource)
    {
        AudioClip clip = SelectRandomClip(alienAudio.footsteps[0].audioClips);
        if (clip == null) return;

        audioSource.PlayOneShot(clip);
    }

    public void PlayRoar()
    {
        AudioClip clip = SelectRandomClip(alienAudio.roarClips);
        if (clip == null) return;
        vocalAudioSource.clip = clip;
        vocalAudioSource.Play();
    }

    PhysicMaterial GetGroundPhysicMaterial()
    {
        // Not yet implemented
        return null;
    }

    AudioClip SelectRandomClip(AudioClip[] clips) =>
        clips[Random.Range(0, clips.Length)];
}
