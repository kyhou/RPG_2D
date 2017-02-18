using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    private float audioLevel;

    public float defautAudio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void SetAudioLevel(float volume)
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioLevel = defautAudio * volume;
        audioSource.volume = audioLevel;
    }
}