using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class MorseSequence : MonoBehaviour
{
    public MorseNote[] sequence;
    // Time between notes that you can wait before the sequence resets
    public const float listenTime = 0.5f;
    private int activeNoteIdx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (MorseNote note in sequence)
        {
            note.Reset();
            note.morse_sequence = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputDetection();
    }

    // constantly check if lmb is pressed
    // either glow the next note or fail if during a dash
    void HandleInputDetection()
    {
        // if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.E))
        {
            sequence[activeNoteIdx].Activate();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetSequence();
        }
    }

    // called by morse note upon completion (immediate for dot, after wait time for dash)
    // go to next idx
    // start listening timer
    public void AdvanceSeqence()
    {
        activeNoteIdx++;
    }

    // called when player fails the sequence, either by taking too long or inturrupting a dash
    public void ResetSequence()
    {
        activeNoteIdx = 0;
        foreach (MorseNote note in sequence)
        {
            note.Reset();
        }
    }
}
