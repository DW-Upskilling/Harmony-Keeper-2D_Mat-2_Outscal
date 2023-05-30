using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public Sound[] soundsList;
    public string backgroundMusicName;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (soundsList != null)
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

    void Start()
    {
        if (backgroundMusicName != null && backgroundMusicName != "")
            Play(backgroundMusicName);
    }

    public void Play(Sound s)
    {
        s.source.Play();
    }

    public void Play(string name)
    {
        if (soundsList == null)
            return;
        Sound s = Array.Find(soundsList, s => s.name == name);
        if (s != null)
            s.source.Play();
    }

    public void Play(string name, bool isEnable)
    {
        if (soundsList == null)
            return;
        Sound s = Array.Find(soundsList, s => s.name == name);
        if (s != null)
            s.source.enabled = isEnable;
    }
}