using UnityEngine;

public class TriggerKnockableArea : MonoBehaviour
{
    //updates canKnock in MorseSequence
    public MorseSequenceBase morseSequenceBase; // Reference to the base class
    public GameObject instructionPanel;


    //player is allowed to knock only in the knockable area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("KnockArea"))
            {
            MorseKnockSequence knockSequence = morseSequenceBase.GetComponent<MorseKnockSequence>();
            if (knockSequence != null)
            {
                knockSequence.canActivate = true;
                instructionPanel.SetActive(true);
            }
            }
            else if (gameObject.CompareTag("WalkArea"))
            {
                MorseWalkSequence walkSequence = morseSequenceBase.GetComponent<MorseWalkSequence>();
                if (walkSequence != null)
                {
                    walkSequence.canActivate = true;
                    //instructionPanel.SetActive(true);
                }
            }
        }
    }
    //player is not allowed to knock outside the knockable area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("KnockArea"))
            {
                MorseKnockSequence knockSequence = morseSequenceBase.GetComponent<MorseKnockSequence>();
                if (knockSequence != null)
                {
                    knockSequence.canActivate = false;
                    instructionPanel.SetActive(false);
                }
            }
            else if (gameObject.CompareTag("WalkArea"))
            {
                MorseWalkSequence walkSequence = morseSequenceBase.GetComponent<MorseWalkSequence>();
                if (walkSequence != null)
                {
                    walkSequence.canActivate = false;
                    //instructionPanel.SetActive(false);
                }
            }
        }
    }
}