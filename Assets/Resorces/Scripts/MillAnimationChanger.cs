using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillAnimationChanger : MonoBehaviour
{
    private Animator _animator;
    private int _numberOfAnimation;    
    private int _currentIteration = 0;
    public int LastAniamtionNumber;
    public int CountOfIteration = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void ChangeAnimationNumber()
    {
        if (CountOfIteration == _currentIteration)
        {
            _numberOfAnimation = Random.Range(1, LastAniamtionNumber);
            _currentIteration = 0;
            _animator.SetInteger("NumberAnimation", _numberOfAnimation);
        }
        else
        {
            _currentIteration++;
        }
    }
}
