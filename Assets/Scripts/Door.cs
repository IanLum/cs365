using UnityEngine;

public class Door : MonoBehaviour
{
    Animator doorAnimator;

    public bool IsOpen = false;

    void Start()
    {
    }
    public void Open()
    {
        doorAnimator.Play("doorSlide", 0, 0.0f);
    }
    public void Close()
    {
        doorAnimator.Play("doorSlide", 0, 0.0f);
    }


}
