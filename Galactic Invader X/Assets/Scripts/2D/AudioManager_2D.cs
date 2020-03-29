using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_2D : MonoBehaviour
{
    public Sound_2D[] sounds;

    public static AudioManager_2D instance;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound_2D s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }
    void Start()
    {
        Play("Theme_2D");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound_2D s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }
        s.source.Play();
    }public void Stop(string name)
    {
        Sound_2D s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found!");
            return;
        }
        s.source.Stop();
    }
}
