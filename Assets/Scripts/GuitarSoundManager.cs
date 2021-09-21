using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class GuitarSoundManager : SoundBase
{
    private AudioSource audioSource;
    private bool isPlaying;

    [Header("Guitar Chords Sound")]
    public SoundLine CChord;
    public SoundLine FsadChord;
    public SoundLine GChord;
    public SoundLine DminChord;
    public SoundLine EminChord;
    public SoundLine AminChord;
    public SoundLine FSharpMinChord;
    public SoundLine BminChord;
    public SoundLine GSharpPowChord;
    
    private AudioClip currentAudioClip;
    private ChordEmotions.Emotions emotionalState;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public bool getIsPlayingBool() {
        return isPlaying;
    }

    private void setIsPlayingBool(bool isPlaying) {
        this.isPlaying = isPlaying;
    }

    public IEnumerator PlayNextGuitarLine(ChordEmotions.Chords chord, float guitarTimeClip) {
        setIsPlayingBool(true);

        switch (chord) {
            case ChordEmotions.Chords.C:
                SetGuitarSoundDetails(CChord);
                break;
            case ChordEmotions.Chords.G:
                SetGuitarSoundDetails(GChord);
                break;
            case ChordEmotions.Chords.Dm:
                SetGuitarSoundDetails(DminChord);
                break;
            case ChordEmotions.Chords.Fs:
                SetGuitarSoundDetails(FsadChord);
                break;
            case ChordEmotions.Chords.Em:
                SetGuitarSoundDetails(EminChord);
                break;
            case ChordEmotions.Chords.Am:
                SetGuitarSoundDetails(AminChord);
                break;
            case ChordEmotions.Chords.Fshmin:
                SetGuitarSoundDetails(FSharpMinChord);
                break;
            case ChordEmotions.Chords.Gshpow:
                SetGuitarSoundDetails(GSharpPowChord);
                break;
            case ChordEmotions.Chords.Bm:
                SetGuitarSoundDetails(BminChord);
                break;
            default:
                Debug.Log("Chord of " + chord + " is not available");
                break;
        }
        
        yield return StartCoroutine(PlayClip(audioSource, currentAudioClip, 0f)); // changed to playclip
        setIsPlayingBool(false);
    }

    private void SetGuitarSoundDetails(SoundLine soundLine) {
        currentAudioClip = soundLine.audioClip;
        emotionalState = soundLine.emotions;
    }

    public ChordEmotions.Emotions getEmotionalState() {
        return emotionalState;
    }
}
