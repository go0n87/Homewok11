using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    Animator animator;
    public GameObject GameManager;
    private CalculateBonus _calcBonus;
    private bool _isTaken = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        _calcBonus = GameManager.GetComponent<CalculateBonus>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (!_isTaken) {_calcBonus.RefreshBonus();}            
            animator.SetBool("IsTaken", true);
            _isTaken = true;
        }
    }

}
