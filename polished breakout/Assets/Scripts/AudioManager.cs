using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    private AudioSource source;
    [SerializeField] private AudioMixer mainMixer;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip, bool randomizePitch = false)
    {
        mainMixer.SetFloat("Pitch", randomizePitch ? Random.Range(0.5f, 1.5f) : 1f);

        source.PlayOneShot(clip);
    }
}
