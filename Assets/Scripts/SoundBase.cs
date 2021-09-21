using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoBehaviour
{

    protected IEnumerator PlayClip(AudioSource audioSource, AudioClip clip, float delay) {
        audioSource.clip = clip;
        audioSource.PlayDelayed(delay);
        yield return new WaitWhile (()=> audioSource.isPlaying);
    }

    protected IEnumerator PlayClipGuitar(AudioSource audioSource, AudioClip clip, float timeToPlayClip) {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(timeToPlayClip);
        audioSource.Stop();
    }
}
