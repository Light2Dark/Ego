using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class KeyboardController : MonoBehaviour
{
    [Header("Input Settings")]
    public PlayerInput playerInput;

    [Header("Sub Behaviours")]
    public Story gameStory;

    //Action Maps
    private string actionMapChordModeControls = "Chords";
    private string actionMapMenuControls = "Menu";
    private string actionMapNoteModeControls = "Notes";

    //Current Control Scheme
    private string currentControlScheme;

    //INPUT SYSTEM ACTION METHODS --------------

    //This is called from PlayerInput; when a joystick or arrow keys has been pushed.

    public void OnCChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.C);
        }
    }

    public void OnGChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.G);
        }
    }

    public void OnFminChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Fs);
        }
    }

    public void OnAMinChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Am);
        }
    }

    public void OnEMinChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Em);
        }
    }
    
    public void OnDMinChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Dm);
        }
    }
    
    public void OnFSharpMinChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Fshmin);
        }
    }

    public void OnGSharpPowChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Gshpow);
        }
    }

    public void OnBMinChord(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            gameStory.ChordPlayed(ChordEmotions.Chords.Bm);
        }
    }


     //Switching Action Maps ----

    public void EnableChordModeControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapChordModeControls);  
    }

    public void EnablePauseMenuControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapMenuControls);
    }

    public void EnableNoteModeControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapNoteModeControls);
    }
}
