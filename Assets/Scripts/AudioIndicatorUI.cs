using UnityEngine;
using UnityEngine.UI;

public class AudioIndicatorUI : MonoBehaviour
{
    public Transform Player;
    public Transform Pivot;
    public Image Indicator;
    const float INDICATOR_DURATION = 0.4f;
    void Start()
    {
        Indicator.CrossFadeAlpha(0f, 0f, false);
        foreach (var emitter in FindObjectsByType<AudioSequenceEmitter>(FindObjectsSortMode.None))
        {
            emitter.AudioEmitted.AddListener(OnAudioEmitted);
        }
    }

    void OnAudioEmitted(AudioSequenceEmitter emitter)
    {
        // TODO: more juice, slight drift forward? smaller indicator that
        // echoes forward? scale size by distance to sound

        // If outside of max dist, do nothing
        Vector3 vec_to_player = (emitter.GetComponent<Transform>().position - Player.position);
        if (vec_to_player.magnitude > emitter.audioSource.maxDistance)
        {
            return;
        }
        // Point indicator towards source of sound
        Vector3 dir = vec_to_player.normalized;
        float angle = Vector3.SignedAngle(dir, Player.forward, Vector3.up);
        Pivot.transform.localEulerAngles = new Vector3(0, 0, angle);

        // Indicator.color = new Color(1, 1, 1, 1f);
        Indicator.CrossFadeAlpha(1f, 0f, false);
        Indicator.CrossFadeAlpha(0f, INDICATOR_DURATION, false);
    }
}
