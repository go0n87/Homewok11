using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillAnimationChanger : MonoBehaviour
{
    private int _numberOfAnimation;
    private float _timeOfIteration;
    private float _timeOfCurrentAnimation;
    private Animator _animator;
    private bool _isMoving;
    private Vector3 _upPosition;
    private Vector3 _downPosition;
    public GameObject Sphere;
    public float UpDistance;
    public int UpAniamtionNumber;
    public int DownAniamtionNumber;
    public int LastAniamtionNumber;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _timeOfIteration = Random.Range(3f, 5f);
        
        _timeOfCurrentAnimation = 0;
        _upPosition = Sphere.transform.localPosition + new Vector3(0f, UpDistance, 0f);
        _downPosition = Sphere.transform.localPosition;
    }    
    void Update()
    {
        _timeOfCurrentAnimation += _isMoving? 0 : Time.deltaTime;

        if (_timeOfCurrentAnimation >= _timeOfIteration && !_isMoving)
        {            
            _numberOfAnimation = _numberOfAnimation == LastAniamtionNumber ? 0 : _numberOfAnimation+1;
            _animator.SetInteger("NumberAnimation", _numberOfAnimation);
            _timeOfIteration = Random.Range(1f, 1f);
            _timeOfCurrentAnimation = 0;

            if (_numberOfAnimation == UpAniamtionNumber || _numberOfAnimation == DownAniamtionNumber)
            {                
                _animator.SetBool("MovingComplete", false);
                _isMoving = true;
                _timeOfCurrentAnimation = 0;
            }
        }
        else if (_isMoving && _numberOfAnimation == UpAniamtionNumber)
        {            
            VerticalMovingMill(_upPosition);
        }
        else if (_isMoving && _numberOfAnimation == DownAniamtionNumber)
        {
            VerticalMovingMill(_downPosition);
        }
    }
    private void VerticalMovingMill(Vector3 position)
    {
        Sphere.transform.localPosition = Vector3.MoveTowards(Sphere.transform.localPosition, position, 0.005f);
        if (Vector3.Distance(position, Sphere.transform.localPosition) < 0.05f)
        {            
            _isMoving = false;
            _animator.SetBool("MovingComplete", true);
        }

    }
}
