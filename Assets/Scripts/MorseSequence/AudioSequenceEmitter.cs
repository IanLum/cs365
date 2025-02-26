using System.Collections;
using UnityEngine;

public class AudioSequenceEmitter : MonoBehaviour
{
    const float DOT_TIME = 0.15f;
    const float DASH_TIME = 0.6f;
    const float TIME_BETWEEN_SEQUENCE = 3f;
    public enum Notes { DOT, DASH };
    public AudioSource audioSource;
    public AudioClip[] audioClips;
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
                AudioClip sound = audioClips[Random.Range(0, audioClips.Length)];
                audioSource.PlayOneShot(sound);
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(TIME_BETWEEN_SEQUENCE);
        }
    }
}
