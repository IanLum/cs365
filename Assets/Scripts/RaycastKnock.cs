using UnityEngine;

public class RaycastKnock : MonoBehaviour
{
    public MorseSequence morseSequence;
    public GameObject instructionPanel;
    private Camera cam;


    void Start()
    {
       cam = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit hit;
        //cam.tranform
        if (Physics.Raycast(transform.position, cam.transform.forward, out hit, 6))
        {
            if (hit.distance > 1.5)
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
}
