using UnityEngine;

public class MorseSequence : MonoBehaviour
{
    public MorseNote[] sequence;
    public Door doorObj;
    public bool hidden;

    private int activeNoteIdx = 0;
    private bool resetting = false;
    public const float listenTime = 0.5f;

    void Start()
    {
        foreach (MorseNote note in sequence)
        {
            note.morse_sequence = this;
        }
        ResetSequence();
    }

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

    public void AdvanceSequence()
    {
        activeNoteIdx++;
        if (activeNoteIdx < sequence.Length)
        {
            Invoke(nameof(ResetSequence), listenTime);
        }
        else
        {
            OnSuccess();
        }
    }

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
        if (doorObj != null)
        {
            doorObj.Open();
            Debug.Log("Morse sequence completed, door opened.");
        }
    }
}
