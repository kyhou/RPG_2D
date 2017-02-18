using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public VolumeController[] vcObjects;
    public float currentVolumeLevel, maxVolumeLevel = 1.0f;

    void Start()
    {
        vcObjects = FindObjectsOfType<VolumeController>();

        if(currentVolumeLevel > maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        for(int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].SetAudioLevel(currentVolumeLevel);
        }
    }

    void Update()
    {

    }
}