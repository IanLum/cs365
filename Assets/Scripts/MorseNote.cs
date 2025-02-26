using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MorseNote : MonoBehaviour
{
    public const float FADE_OUT_TIME = 0.5f;
    // Unkown units, not lumens
    const int DEFAULT_LIGHT_INTENSITY = 400;
    const int FLASH_LIGHT_INTENSITY = 2000;
    const float FLASH_DURATION = 0.3f;
    // Set by the [MorseSequence] that owns the note
    [HideInInspector]
    public MorseSequence morse_sequence;
    public GameObject glowImg;
    public Light lightObj;
    private bool complete = false;


    protected virtual void Start()
    {
        Reset();
    }

    // called by [MorseSequence] when it's this note's turn in the sequence and lmb pressed
    // returns true except if dash was interrupted
    public virtual bool Activate()
    {
        glowImg.GetComponent<Image>().CrossFadeAlpha(1f, 0f, false);
        lightObj.intensity = DEFAULT_LIGHT_INTENSITY;
        return true;
    }

    protected virtual void Complete()
    {
        complete = true;
        Flash();
        morse_sequence.AdvanceSeqence();
    }

    public virtual void Reset()
    {
        complete = false;
        Coroutine fade = StartCoroutine(Fade());
    }

    protected virtual IEnumerator Fade()
    {
        lightObj.DOIntensity(0, FADE_OUT_TIME / 3);
        glowImg.GetComponent<Image>().CrossFadeAlpha(0f, FADE_OUT_TIME, false);
        yield return new WaitForSeconds(FADE_OUT_TIME);
    }

    void Flash()
    {
        lightObj.intensity = FLASH_LIGHT_INTENSITY;
        lightObj.DOIntensity(DEFAULT_LIGHT_INTENSITY, FLASH_DURATION);
    }

}
