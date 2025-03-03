using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;

public class MorseSequence : MonoBehaviour
{
    public MorseNote[] sequence;
    public Door doorObj;
    public bool hidden;
    //records if the player is in the knockable range. It is updated in RaycastKnock
    public bool canKnock = false;
    [SerializeField] private bool closeTrigger = false;
    // Time between notes that you can wait before the sequence resets
    public const float listenTime = 0.5f;
    private int activeNoteIdx = 0;
    [SerializeField] private AudioClip beep;
    private int count;
    //call the arm object that has the animator
    public GameObject arm;
    public Animator animator;
    public GameObject tutorialPanel;

    bool resetting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (MorseNote note in sequence)
        {
            note.morse_sequence = this;
        }
        //get the animator
        animator = arm.GetComponent<Animator>();
        Invoke("ResetSequence", 0f);
    }
  
            // Update is called once per frame
        void Update()
        {
        if (canKnock)
        {
            HandleInputDetection();
       }
        }

    // constantly check if lmb is pressed
    // either glow the next note or fail if during a dash
    void HandleInputDetection()
    {
        //shows the tutorial until player press the "e" for the firs time
        if (count == 0)
        {
            tutorialPanel.SetActive(true);
        }
        else
        {
            tutorialPanel.SetActive(false);
        }

        // if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.E) && !resetting)
        {
            //ToggleInstructionPanel();
            count++;
            //if press "E" set to speedbag
            animator.SetTrigger("KnockTrigger");

            bool knockHeard = sequence[activeNoteIdx].Activate();
            if (knockHeard)
            {
                AudioSource.PlayClipAtPoint(beep, transform.position, 1f);
                CancelInvoke("ResetSequence");

            }
            else
            {
                // dash inturrupted
                ResetSequence();
            }
        }
 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetSequence();
        }
    }



    // called by morse note upon completion (immediate for dot, after wait time for dash)
    // go to next idx
    // start listening timer
    public void AdvanceSeqence()
    {
        activeNoteIdx++;
        if (activeNoteIdx < sequence.Length)
        {
            // threaten to reset the sequence if the player takes too long
            Invoke("ResetSequence", listenTime);
        }
        else
        // sequence complete
        {
            doorObj.Open();
        }
    }

    // called when player fails the sequence, either by taking too long or inturrupting a dash
    public void ResetSequence()
    {
        resetting = true;
        Invoke("StopResetting", MorseNote.FADE_OUT_TIME);

        activeNoteIdx = 0;
        foreach (MorseNote note in sequence)
        {
            note.Reset(hidden);
        }
    }

    void StopResetting()
    {
        resetting = false;
    }
}
