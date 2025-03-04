using UnityEngine;

public class TriggerKnockableArea : MonoBehaviour
{
    //updates canKnock in MorseSequence
    public MorseSequence morseSequence;
    public GameObject instructionPanel;


    //player is allowed to knock only in the knockable area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            morseSequence.canKnock = true;
            instructionPanel.SetActive(true);
        }
    }
    //player is not allowed to knock outside the knockable area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            morseSequence.canKnock = false;
        }
    }
}