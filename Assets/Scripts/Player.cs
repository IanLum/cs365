using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 6f;
    public AudioClip footstepSound;
    public AudioClip knockSound;
    public GameObject instructionPanel;

    private BaseArea currentArea = null;

    void Update()
    {
        DetectArea(); // Continuously check if the player is in an interactive area

        if (currentArea == null) return; // Ignore input if not in an area

        // Check for knock input
        if (Input.GetKeyDown(KeyCode.E) && currentArea is KnockableArea)
        {
            PerformKnock();
        }

        // Check for walk input
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
             Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && currentArea is WalkSeqArea)
        {
            PerformWalk();
        }
    }

    private void PerformKnock()
    {
        Debug.Log("Player is knocking.");
        AudioSource.PlayClipAtPoint(knockSound, transform.position, 1f);
        instructionPanel.SetActive(false);
        (currentArea as KnockableArea).morseSequence.HandleActivation();
    }

    private void PerformWalk()
    {
        Debug.Log("Player is walking.");
        AudioSource.PlayClipAtPoint(footstepSound, transform.position, 1f);
        instructionPanel.SetActive(false);
        (currentArea as WalkSeqArea).morseSequence.HandleActivation();
    }

    private void DetectArea()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.distance > 1.5f)
            {
                BaseArea detectedArea = hit.collider.GetComponent<BaseArea>();
                if (detectedArea != null)
                {
                    currentArea = detectedArea;
                    instructionPanel.SetActive(true);
                    return;
                }
            }
        }

        // If no area detected, reset
        currentArea = null;
        instructionPanel.SetActive(false);
    }
}