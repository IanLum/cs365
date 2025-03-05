using System.Collections;
using UnityEngine;

public class AudioSequenceEmitter : MonoBehaviour
{
    const float DOT_TIME = 0.2f;
    const float DASH_TIME = 0.7f;
    const float TIME_BETWEEN_SEQUENCE = 4f;
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
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(TIME_BETWEEN_SEQUENCE);
        }
    }
}
