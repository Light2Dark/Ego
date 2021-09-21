using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChordEmotions : object
{
    public enum Chords {
        C, G, Dm, Fs, Em, Am, Fshmin, Gshpow, Bm
    }

    public enum Emotions {
        happy, sad, fear, anger
    }

    public static Dictionary<Chords, Emotions> ChordToEmotion = new Dictionary<Chords, Emotions>() {
        {Chords.C, Emotions.happy},
        {Chords.G, Emotions.happy},
        {Chords.Dm, Emotions.fear},
        {Chords.Em, Emotions.anger},
        {Chords.Fs, Emotions.sad},
        {Chords.Gshpow, Emotions.anger},
        {Chords.Bm, Emotions.sad},
        {Chords.Fshmin, Emotions.fear},
        {Chords.Am, Emotions.sad}
    };

    public static Emotions ConvertChordToEmotion(Chords chord) {
        return ChordToEmotion[chord];
    }
    
}
