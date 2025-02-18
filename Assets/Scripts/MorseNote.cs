using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MorseNote : MonoBehaviour
{
    const float FADE_OUT_TIME = 0.5f;
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
        glowObj.GetComponent<Image>().CrossFadeAlpha(1f, 0f, false);
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
        Coroutine fade = StartCoroutine(Fade());
    }

    protected virtual IEnumerator Fade()
    {
        glowObj.GetComponent<Image>().CrossFadeAlpha(0f, FADE_OUT_TIME, false);
        yield return new WaitForSeconds(FADE_OUT_TIME);
    }

}
