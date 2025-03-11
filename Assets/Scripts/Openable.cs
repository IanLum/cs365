using UnityEngine;

public class Openable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject obstacle;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Open()
    {
        anim.Play("slide door right", 0, 0.0f);
    }
}
