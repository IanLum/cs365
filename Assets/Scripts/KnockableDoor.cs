using UnityEngine;
public class KnockableDoor : MonoBehaviour
{
    public void Knocking()
    {
        Debug.Log("Knocked on " + gameObject.name);
    }
}
