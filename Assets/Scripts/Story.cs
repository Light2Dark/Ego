using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    [Header("Manager Settings")]
    public DialogueManager dialogueManager;
    public GuitarSoundManager guitarSoundManager;
    public SoundtrackManager soundtrackManager;

    [Header("Win Lose")]
    public int lives = 3;
    public event System.Action OnDeathEvent;
    public event System.Action OnHurtEvent;
    //FindObjectOfType<playerMove>().OnPlayerDeath += OnGameOver;

    [Header("General Audio Settings")]
    public float generalDialogueDelay = 0.3f;
    public float generalTimeWaitInput = 1f;
    public float generalGuitarChordDelay = 0.3f;
    public float guitarChordTimeClip = 1f;
    
    private bool userPlayedChord;
    private bool dialogueCoroutineIsRunning;
    private bool guitarCoroutineIsRunning;
    private IEnumerator currentGuitarCoroutine;
    private IEnumerator currentDialogueCoroutine;
    private IEnumerator currentClipFinishCoroutine;

    public bool gameStart;

    public void setGameStart(bool start) {
        gameStart = start;
    }

    private enum Characters {
        Jenna,
        Tom,
        Guitar,
        Soundtrack
    }

    public enum EmotionalState {
        happy,
        sad, 
        fear,
        anger
    }

    private ChordEmotions.Emotions currentGuitarEmotion;
    private ChordEmotions.Emotions currentDialogueEmotion;
    private Characters currentCharacterSpeaking;
    private bool dialogueHurts;

    /************ GAME LOOP ******************/

    void Start() {

    }

    public void StartGame() { // call this function from button
        if (dialogueCoroutineIsRunning == false) {
            // first dialogue line is sad
            StartCoroutine(PlayDialogue(ChordEmotions.Emotions.sad, generalDialogueDelay, true, generalTimeWaitInput)); 
        }
    }

    private IEnumerator WaitForInput(bool inputNeeded, float time) {
        if (inputNeeded) {
            yield return new WaitUntil(() => userPlayedChord == true); // wait until user plays chord through ChordPlayed method
            userPlayedChord = false;
        }
        yield return new WaitForSeconds(time);
    }

    // IGNORE METHOD BELOW
    private IEnumerator WaitUntilClipFinishes(bool dialogue) {
        if (dialogue) {
            yield return new WaitUntil(() => dialogueManager.getCanPlayDialogue() == true); // wait until dialogue audioclip is finished. for now this should be a double check system since its alrdy implemented in dialogue manager class
        } else {
            yield return new WaitUntil(() => guitarSoundManager.getIsPlayingBool() == false); // wait until guitar audioclip is finished
        }
    }

    private IEnumerator PlayDialogue(ChordEmotions.Emotions emotion, float dialogueDelay, bool inputNeeded, float timeWaitForInput) {
        if (gameStart) {
            dialogueCoroutineIsRunning = true;
            yield return StartCoroutine(dialogueManager.PlayNextDialogueLine(emotion, dialogueDelay));
            
            setEmotionalState(dialogueManager.getEmotionalState(), true);
            if (dialogueManager.getDialogueHurts()) {
                LoseLife();
            }

            yield return StartCoroutine(WaitForInput(true, timeWaitForInput));

            dialogueCoroutineIsRunning = false;
        }
    }


    /* Handling Win/lose */

    private void OnDeath() {
        if (OnDeathEvent != null) {
            OnDeathEvent();
            Debug.Log("death");
        }
    }

    private void LoseLife() {
        lives--;
        if (lives == 0) {
            OnDeath();
        } else if (lives > 0) {
            OnHurt();
        }
    }

    private void OnHurt() {
        if (OnHurtEvent != null) {
            OnHurtEvent();
            Debug.Log("hurt");
        }
    }


    // Keyboard Input

    public void ChordPlayed(ChordEmotions.Chords chord) {
        
        userPlayedChord = true;
        ChordEmotions.Emotions emotion = ChordEmotions.ConvertChordToEmotion(chord);

        StartCoroutine(PlayChord(chord));
        StartCoroutine(PlayDialogue(emotion, generalDialogueDelay, true, generalTimeWaitInput));
    }

    public IEnumerator PlayChord(ChordEmotions.Chords chord) {

        if (guitarCoroutineIsRunning) {
            yield return null;

        } else {
            guitarCoroutineIsRunning = true;
            yield return StartCoroutine(guitarSoundManager.PlayNextGuitarLine(chord, guitarChordTimeClip));
            guitarCoroutineIsRunning = false;
        }
        
    }

    // Emotional State

    private void setEmotionalState(ChordEmotions.Emotions emotion, bool dialogue) {

        if (dialogue) {
            currentDialogueEmotion = emotion;
        } else {
            currentGuitarEmotion = emotion;
        }
    }
    
}
