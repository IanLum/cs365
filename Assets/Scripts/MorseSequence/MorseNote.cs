using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MorseNote : MonoBehaviour
{
    public const float FADE_OUT_TIME = 0.5f;
    // Unkown units, not lumens
    const float DEFAULT_LIGHT_INTENSITY = 0.1f;
    const float FLASH_LIGHT_INTENSITY = 0.4f;
    const float FLASH_DURATION = 0.3f;
    // Set by the [MorseSequence] that owns the note
    [HideInInspector]
    public MorseSequence morse_sequence;
    public GameObject glowImg;
    public Light lightObj;
    //private bool complete = false;


    protected virtual void Start()
    {
        // Reset();
        return;
    }

    // called by [MorseSequence] when it's this note's turn in the sequence and lmb pressed
    // returns true except if dash was interrupted
    public virtual bool Activate()
    {
        // this.gameObject.SetActive(true);
        this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1);
        glowImg.GetComponent<Image>().CrossFadeAlpha(1f, 0f, false);
        lightObj.intensity = DEFAULT_LIGHT_INTENSITY;
        return true;
    }

    protected virtual void Complete()
    {
        //complete = true;
        Flash();
        morse_sequence.AdvanceSequence();
    }

    public virtual void Reset(bool hidden)
    {
        //complete = false;
        Coroutine fade = StartCoroutine(Fade(hidden));
    }

    protected virtual IEnumerator Fade(bool hidden)
    {
        lightObj.DOIntensity(0, FADE_OUT_TIME / 3);
        glowImg.GetComponent<Image>().CrossFadeAlpha(0f, FADE_OUT_TIME, false);
        yield return new WaitForSeconds(FADE_OUT_TIME);
        if (hidden)
        {
            this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }

    void Flash()
    {
        lightObj.intensity = FLASH_LIGHT_INTENSITY;
        lightObj.DOIntensity(DEFAULT_LIGHT_INTENSITY, FLASH_DURATION);
    }

}
