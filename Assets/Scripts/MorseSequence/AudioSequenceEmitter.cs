using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AudioSequenceEmitter : MonoBehaviour
{
    const float DOT_TIME = 0.2f;
    const float DASH_TIME = 0.7f;
    const float TIME_BETWEEN_SEQUENCE = 4f;
    // AudioIndicatorUI connects to this signal
    public UnityEvent<AudioSequenceEmitter> AudioEmitted;
    public enum Notes { DOT, DASH };
    public AudioSource audioSource;
    public Notes[] sequence;
    void Start()
    {
        Coroutine _ = StartCoroutine(LoopAudioSequence());
    }

    IEnumerator LoopAudioSequence()
    {
        while (true)
        {
            foreach (Notes note in sequence)
            {
                float waitTime = (note == Notes.DOT) ? DOT_TIME : DASH_TIME;
                audioSource.Play();
                AudioEmitted.Invoke(this);
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(TIME_BETWEEN_SEQUENCE);
        }
    }
}
