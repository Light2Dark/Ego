using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class DialogueManager : SoundBase
{
    private AudioSource audioSource;
    private bool canPlayDialogue;

    /* DIALOGUE LINES */
    [Header("Dialogue Lines")]
    public SoundLine[] happyDialogueLines; // 50 lines
    public SoundLine[] sadDialogueLines;
    public SoundLine[] fearDialogueLines;
    public SoundLine[] angerDialogueLines;
    private int dialogueLineNum = 0;

    private AudioClip currentDialogueAudio; // pull each dialogue audio to play
    private SoundLine.Characters character;
    private ChordEmotions.Emotions emotionalState;
    private bool dialogueHurts;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public bool getCanPlayDialogue() {
        return canPlayDialogue;
    }

    private void setCanPlayDialogue(bool canPlay) {
        canPlayDialogue = canPlay;
    }

    private void SetDialogueDetails(SoundLine soundLine) {
        character = soundLine.characterName;
        currentDialogueAudio = soundLine.audioClip;
        emotionalState = soundLine.emotions;
        dialogueHurts = soundLine.dialogueLineHurts;
    }

    public IEnumerator PlayNextDialogueLine(ChordEmotions.Emotions emotion, float delay) {
        Debug.Log(dialogueLineNum);
        setCanPlayDialogue(false);

        switch (emotion) {

            case ChordEmotions.Emotions.happy:
                if (happyDialogueLines[dialogueLineNum] != null) {
                    Debug.Log("happy increase");
                    SetDialogueDetails(happyDialogueLines[dialogueLineNum]);
                    yield return StartCoroutine(AdvanceDialogue(delay));               
                }
                break;

            case ChordEmotions.Emotions.sad: 
                if (sadDialogueLines[dialogueLineNum] != null) {
                    SetDialogueDetails(sadDialogueLines[dialogueLineNum]);
                    yield return StartCoroutine(AdvanceDialogue(delay));               
                }
                break;
                
            case ChordEmotions.Emotions.fear:
                if (fearDialogueLines[dialogueLineNum] != null) {
                    SetDialogueDetails(fearDialogueLines[dialogueLineNum]);
                    yield return StartCoroutine(AdvanceDialogue(delay));               
                }
                break;

            case ChordEmotions.Emotions.anger:
                if (angerDialogueLines[dialogueLineNum] != null) {
                    SetDialogueDetails(angerDialogueLines[dialogueLineNum]);
                    yield return StartCoroutine(AdvanceDialogue(delay));               
                }
                break;

            default:
                Debug.Log("ERROR! Wrong dialogue emotional state chosen");
                break;
        } 
    }

    public IEnumerator AdvanceDialogue(float delay) {
        yield return StartCoroutine(PlayClip(audioSource, currentDialogueAudio, delay));
        setCanPlayDialogue(true);
        IncreaseDialogueLineNum();     
    }

    private void IncreaseDialogueLineNum() {
        dialogueLineNum++;
    }

    
    // Emotional State Getter
    public ChordEmotions.Emotions getEmotionalState() {
        return emotionalState;
    }

    public bool getDialogueHurts() {
        return dialogueHurts;
    }

}
