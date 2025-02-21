using UnityEngine;

public class MorseKnockSequence : MorseSequenceBase
{
    public Door doorObj;
    public GameObject arm;
    public Animator animator;
    public AudioClip beep;
    public GameObject tutorialPanel;

    void Start()
    {
        Debug.Log($"{this.name}: MorseKnockSequence Start() called");

    // Call the base Start() to assign the morse_sequence
        base.Start();
        animator = arm.GetComponent<Animator>();  // Get animator from the arm object
    }

    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.E) && !resetting)
        {
            PerformKnock();  // Trigger the knock sequence
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetSequence();  // Manual reset
        }
    }

    private void PerformKnock()
    {
        // Knock-specific behavior before calling base activation
        animator.SetTrigger("KnockTrigger");  // Play knock animation
        AudioSource.PlayClipAtPoint(beep, transform.position, 1f);  // Play knock sound

        // Call base class logic to progress the sequence
        HandleActivation();

        // Additional feedback (optional)
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);  // Hide tutorial after first knock
        }
    }

    // Called when the sequence is successfully completed
    protected override void OnSuccess()
    {
        if (doorObj != null)
        {
            doorObj.Open();  // Open the door when the sequence is complete
            Debug.Log("Knock sequence succeeded! Door opened.");
        }
        else
        {
            Debug.LogWarning("Door object is not assigned.");
        }
    }
}
