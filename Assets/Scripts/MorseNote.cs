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
    public virtual void Activate()
    {
        glowObj.SetActive(true);
    }

    protected virtual void Complete()
    {
        complete = true;
        morse_sequence.AdvanceSeqence();
    }

    public virtual void Reset()
    {
        Debug.Log(this, glowObj);
        complete = false;
        glowObj.SetActive(false);
    }
}
