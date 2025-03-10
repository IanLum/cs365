using UnityEngine;

public class BendTree : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    // JUST FOR TESTING
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BendUp();
        }
    }

    void BendUp()
    {
        animator.Play("BendUp", 0, 0.0f);
    }
}
