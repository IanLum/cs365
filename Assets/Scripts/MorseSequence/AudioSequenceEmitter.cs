using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AudioSequenceEmitter : MonoBehaviour
{
    const float DOT_TIME = 0.2f;
    const float DASH_TIME = 0.7f;
    const float TIME_BETWEEN_SEQUENCE = 4f;
    // AudioIndicatorUI connects to this signal
    [HideInInspector] public UnityEvent<AudioSequenceEmitter> AudioEmitted;
    public enum Notes { DOT, DASH };
    public AudioSource audioSource;
    // Optional, expects non looping particle system
    public ParticleSystem particleSystemObj;
    // Waits this amount between spawning a particle and playing sound
    // Causes unexpected behavior if longer than DOT_TIME
    public float particleDuration;
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
                if (particleSystemObj != null)
                {
                    particleSystemObj.Play();
                    yield return new WaitForSeconds(particleDuration);
                }
                audioSource.Play();
                AudioEmitted.Invoke(this);
                yield return new WaitForSeconds(waitTime - particleDuration);
            }
            yield return new WaitForSeconds(TIME_BETWEEN_SEQUENCE - particleDuration);
        }
    }
}
