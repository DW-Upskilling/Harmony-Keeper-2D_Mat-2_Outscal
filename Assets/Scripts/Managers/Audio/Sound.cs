using UnityEngine;

namespace Outscal.UnityFundamentals.Mat2.Managers.Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name; // Name of the sound effect
        public AudioClip clip; // Audio clip for the sound effect
        [Range(0f, 1f)]
        public float volume; // Volume of the sound effect (0 to 1)
        [Range(.1f, 3f)]
        public float pitch; // Pitch of the sound effect (0.1 to 3)
        [Range(0, 256)]
        public int priority; // Priority of the sound effect (0 to 256)

        public bool loop; // Indicates if the sound effect should loop
        public bool mute; // Indicates if the sound effect should be muted

        [HideInInspector]
        public AudioSource source; // Reference to the AudioSource component for this sound effect
    }
}
