using UnityEngine;
using UnityEngine.Rendering;

public class MorseNote : MonoBehaviour
{
    // Set by the [MorseSequence] that owns the note
    [HideInInspector]
    public MorseSequence morse_sequence;
    public GameObject glowObj;
    private bool complete = false;


    protected virtual void Start()
    {
        Reset();
    }

    // called by [MorseSequence] when it's this note's turn in the sequence and lmb pressed
    // returns true except if dash was interrupted
    public virtual bool Activate()
    {
        glowObj.SetActive(true);
        return true;
    }

    protected virtual void Complete()
    {
        complete = true;
        morse_sequence.AdvanceSeqence();
    }

    public virtual void Reset()
    {
        complete = false;
        glowObj.SetActive(false);
    }
}
