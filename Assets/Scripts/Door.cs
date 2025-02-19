using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null;
    void Start()
    {
    }
    public void Open()
    {
        doorAnimator.Play("DoorOpen", 0, 0.0f);
    }
    public void Close()
    {
        doorAnimator.Play("DoorClose", 0, 0.0f);
    }
}
