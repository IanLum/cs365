using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public List<float> correctPattern = new List<float> { 0.5f, 1.0f, 1.5f }; // put in timing pattern here
    private List<float> playerPattern = new List<float>();
    private float lastKnockTime;

    public float maxAllowedTime = 2.0f; // window frame to complete the pattern

    void Knock()
    {
        float timeSinceLastKnock = Time.time - lastKnockTime;
        lastKnockTime = Time.time;

        playerPattern.Add(timeSinceLastKnock);

        // If player finishes entering the pattern
        if (playerPattern.Count == correctPattern.Count)
        {
            if (ValidatePattern())
            {
                Debug.Log("Correct Knock Pattern!");
                // Trigger door open, animation, etc.
            }
            else
            {
                Debug.Log("Incorrect Knock Pattern.");
                playerPattern.Clear(); // Reset pattern if incorrect
            }
        }
    }

    bool ValidatePattern()
    {
        for (int i = 0; i < correctPattern.Count; i++)
        {
            if (Mathf.Abs(correctPattern[i] - playerPattern[i]) > 0.2f) // allow margin of error
            {
                return false;
            }
        }
        return true;
    }
}
