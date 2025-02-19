using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    public Door doorObj;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(closeTrigger) {
                doorObj.Close();
            }
        }
    }
}
