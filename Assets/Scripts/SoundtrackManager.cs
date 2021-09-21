using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class SoundtrackManager : SoundBase
{
    //[Header("Audio Source Settings")]
    private AudioSource audioSource;

    [Header("Soundtracks")]
    public AudioClip firstTrack;

    void Start() {
        audioSource = this.GetComponent<AudioSource>();
    }
}
