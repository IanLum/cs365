using UnityEngine;

public class PlayerKnock : MonoBehaviour
{
    public float knockRange = 2f; // distance within which player can knock
    public KeyCode knockKey = KeyCode.A; // change if needed

    //void Update()
    //{
    //    if (Input.GetKeyDown(knockKey))
    //    {
    //        TryKnock();
    //    }
    //}

    //void TrytKnock()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, knockRange))
    //    {
    //        KnockableObject knockable = hit.collider.GetComponent<KnockableObject>();
    //        if (knockable != null)
    //        {
    //            knockable.Knock();
    //        }
    //        else
    //        {
    //            Debug.Log("Not a knockable object.");
    //        }
    //    }
    //}
}
