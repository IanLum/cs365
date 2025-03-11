using UnityEngine;

public class Door : Openable
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private string openAnimation = "DoorOpen";  // Default open animation

    public override void Open()
    {
        if (doorAnimator != null)
        {
            doorAnimator.Play(openAnimation, 0, 0.0f);
            Debug.Log($"Opening door: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"No animator found for {gameObject.name}.");
        }
    }
}
