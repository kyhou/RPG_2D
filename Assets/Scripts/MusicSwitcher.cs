using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private MusicController musicController;

    public int newTrack;
    public bool switchOnStart;

    void Start()
    {
        musicController = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            musicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            musicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}