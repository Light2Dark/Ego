using UnityEngine;

[CreateAssetMenu(fileName = "Sound Line", menuName = "Sound Line")]
public class SoundLine : ScriptableObject
{
    public enum Characters {
        Jenna,
        Tom,
        Guitar,
        Soundtrack
    }

    [Header("Character Details")]
    public Characters characterName;
    public ChordEmotions.Emotions emotions;
    
    [Header("Audio Settings")]
    public AudioClip audioClip;

    public bool dialogueLineHurts;

}
