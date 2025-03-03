using UnityEngine;

public class RaycastKnock : MonoBehaviour
{
    public MorseSequence morseSequence;
    public GameObject instructionPanel;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, 6))
        {

            var selection = hit.transform;
            if (selection.CompareTag("Obstacle"))
            {
                morseSequence.canKnock = true;
            }
            else
            {
                morseSequence.canKnock = false;
                instructionPanel.SetActive(false);
            }
        }
        else
        {
            morseSequence.canKnock = false;
            instructionPanel.SetActive(false);
        }
    }
}
