using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public Sound[] soundsList; // List of sound effects
    public string backgroundMusicName; // Name of the background music

    void Awake()
    {
        // Singleton pattern to ensure only one AudioManager instance exists
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Create AudioSource components for each sound effect in the list
        if (soundsList != null)
        {
            foreach (Sound sound in soundsList)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();

                source.name = sound.name;
                source.clip = sound.clip;
                source.volume = sound.volume;
                source.pitch = sound.pitch;
                source.mute = sound.mute;
                source.loop = sound.loop;
                source.priority = sound.priority;

                sound.source = source;
            }
        }
    }

    void Start()
    {
        // Play the background music if a name is provided
        if (!string.IsNullOrEmpty(backgroundMusicName))
        {
            Play(backgroundMusicName);
        }
    }

    // Play a sound effect by Sound object
    public void Play(Sound s)
    {
        s.source.Play();
    }

    // Play a sound effect by name
    public void Play(string name)
    {
        if (soundsList == null)
            return;

        Sound s = Array.Find(soundsList, s => s.name == name);
        if (s != null)
        {
            s.source.Play();
        }
    }

    // Enable or disable a sound effect by name
    public void Play(string name, bool isEnable)
    {
        if (soundsList == null)
            return;

        Sound s = Array.Find(soundsList, s => s.name == name);
        if (s != null)
        {
            s.source.enabled = isEnable;
        }
    }
}
