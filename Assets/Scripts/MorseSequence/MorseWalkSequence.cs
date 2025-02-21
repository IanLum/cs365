using UnityEngine;

public class MorseWalkSequence : MorseSequenceBase
{
    public AudioClip footstep;

    void Start()
    {
        Debug.Log($"{this.name}: MorseKnockSequence Start() called");
        base.Start();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
             Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && !resetting && canActivate)
             {
                PerformWalk();  // Trigger the knock sequence
             }
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetSequence();  // Manual reset
        }
    }

    private void PerformWalk()
    {
        AudioSource.PlayClipAtPoint(footstep, transform.position, 1f);  // Play knock sound

        // Call base class logic to progress the sequence
        HandleActivation();
    }

    // Called when the sequence is successfully completed
    protected override void OnSuccess()
    {
        Debug.Log("Success!!!");
    }
}
