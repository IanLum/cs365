using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerPlayerTag : MonoBehaviour
{
    Animator _Anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Anim = this.GetComponent<Animator>();  // Fixed the assignment operator
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Anim.SetTrigger("DoorTrigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Anim.SetTrigger("DoorTrigger");
        }
    }
}