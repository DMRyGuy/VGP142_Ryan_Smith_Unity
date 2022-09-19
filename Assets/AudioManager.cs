using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    // Awake is called right before the Start
    // Putting sounds in Awake so they can play in the Start
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    // Update is called once per frame
    public void Play (string name)
    {
        // could do another for each but instead add using System
        Sound s = Array.Find(sounds, sound => sound.name ==name);
        s.source.Play();
    }
}
