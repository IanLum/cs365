using UnityEngine;

public abstract class Openable : MonoBehaviour
{
    protected bool isOpened = false; // Check if the object is already opened

    // Opening the object (to be overridden)
    public virtual void Open()
    {
        if (isOpened) return; // Prevent multiple openings
        isOpened = true;
    }
}
