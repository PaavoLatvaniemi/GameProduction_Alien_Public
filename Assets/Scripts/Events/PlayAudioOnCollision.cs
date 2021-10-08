using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnCollision : MonoBehaviour
{
    [SerializeField] float minTriggerForce;
    [SerializeField] float timeBetweenCollisions = .1f;
    [SerializeField] float volume = 1f;
    [SerializeField] AudioClip[] clips;

    AudioSource audioSource;
    float time;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (time > 0) return;
        if (collision.impulse.magnitude < minTriggerForce) return;

        float clampedVolume = Mathf.Clamp01(collision.impulse.magnitude * volume);

        PlayClip(clampedVolume);
        time = timeBetweenCollisions;
    }

    private void Update()
    {
        if (time > 0f) time -= Time.deltaTime;
        if (time < 0f) time = 0f;
    }

    public void PlayClip(float volume)
    {
        AudioClip clip = RandomUtils<AudioClip>.RandomFromArray(clips);
        if(clip != null)
            audioSource.PlayOneShot(clip, volume);
    }
}
