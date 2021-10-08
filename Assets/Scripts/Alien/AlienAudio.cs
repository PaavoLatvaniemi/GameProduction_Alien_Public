using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlienAudio", menuName = "Alien/Alien Audio")]
public class AlienAudio : ScriptableObject
{
    [System.Serializable]
    public class FootstepAudioClipEntry
    {
        public PhysicMaterial groundMaterial;
        public AudioClip[] audioClips;
    }

    public List<FootstepAudioClipEntry> footsteps;
    public AudioClip[] roarClips;
    public AudioClip[] idleClips;

}
