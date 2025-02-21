using UnityEngine;

public abstract class MorseSequenceBase : MonoBehaviour
{
    public MorseNote[] sequence;
    public bool canActivate = false;
    private float listenTime = 0.5f;
    protected int activeNoteIdx = 0;
    protected bool resetting = false;

protected virtual void Start()
{
    Debug.Log($"MorseSequenceBase Start() called for {this.name}");
    foreach (MorseNote note in sequence)
    {
        if (note != null)
        {
            note.morse_sequence = this;
            Debug.Log($"Assigned {this.name} to {note.name}");
        }
        else
        {
            Debug.LogError("Null MorseNote in sequence!");
        }
    }
}

    public virtual void HandleActivation()
    {
        if (activeNoteIdx >= sequence.Length) return;

        bool success = sequence[activeNoteIdx].Activate();
        if (success)
        {
            CancelInvoke("ResetSequence");
        }
        else
        {
            ResetSequence();
        }
    }

    public void AdvanceSequence()
    {
        activeNoteIdx++;
        if (activeNoteIdx < sequence.Length)
        {
            Invoke("ResetSequence", listenTime);
        }
        else
        {
            OnSuccess();  // Call child-specific success behavior
        }
    }

    public void ResetSequence()
    {
        resetting = true;
        Invoke("StopResetting", MorseNote.FADE_OUT_TIME);
        activeNoteIdx = 0;
        foreach (MorseNote note in sequence)
        {
            note.Reset();
        }
    }

    void StopResetting()
    {
        resetting = false;
    }

    protected abstract void OnSuccess();  // Child must implement this
}
