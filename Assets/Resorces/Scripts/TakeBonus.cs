using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("+");
        if (other.gameObject.tag == "Ball")
        {
            animator.SetBool("IsTaken", true);
        }
    }

}
