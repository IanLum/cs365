using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;

public class MorseSequence : MonoBehaviour
{
    public MorseNote[] sequence;
    public bool hidden;
    private int activeNoteIdx = 0;
    private bool resetting = false;
    public const float listenTime = 0.5f;
    public Openable openableObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (MorseNote note in sequence)
        {
            note.morse_sequence = this;
        }
        ResetSequence();
    }

    // constantly check if lmb is pressed
    // either glow the next note or fail if during a dash
    public void HandleActivation()
    {
        if (resetting || activeNoteIdx >= sequence.Length) return;
        bool success = sequence[activeNoteIdx].Activate();
        if (success)
        {
            CancelInvoke(nameof(ResetSequence));
        }
        else
        {
            ResetSequence();
        }
    }



    // called by morse note upon completion (immediate for dot, after wait time for dash)
    // go to next idx
    // start listening timer
    public void AdvanceSequence()
    {
        activeNoteIdx++;
        if (activeNoteIdx < sequence.Length)
        {
            // threaten to reset the sequence if the player takes too long
            Invoke(nameof(ResetSequence), listenTime);
        }
        else
        // sequence complete
        {
            OnSuccess();
        }
    }

    // called when player fails the sequence, either by taking too long or inturrupting a dash
    public void ResetSequence()
    {
        resetting = true;
        Invoke(nameof(StopResetting), MorseNote.FADE_OUT_TIME);

        activeNoteIdx = 0;
        foreach (MorseNote note in sequence)
        {
            note.Reset(hidden);
        }
    }

    void StopResetting()
    {
        resetting = false;
    }

    protected virtual void OnSuccess()
    {
        if (openableObject != null)
        {
            openableObject.Open();
            Debug.Log("Morse sequence completed.");
        }
    }
}
