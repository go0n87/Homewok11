using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public KeyCode MoveForvard;
    public KeyCode MoveTovad;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode Jump;
    public float MoveSpeed;
    public float JumpForce;
    private bool _isGrounded;
    private bool _isMovingAnimation = false;
    private Rigidbody _rb;
    private Animator _currentAnimator;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentAnimator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }
    private void MovementLogic()
    {
        if (Input.GetKey(MoveForvard))
            {
                Vector3 movement = new Vector3(0.1f, 0.0f, 0.0f);
                transform.position += movement;
                //_rb.AddForce(movement * MoveSpeed);
                _currentAnimator.SetBool("isMoving", true);
                _isMovingAnimation = true;
            }
        if (Input.GetKey(MoveTovad))
            {
                Vector3 movement = new Vector3(-0.1f, 0.0f, 0.0f);
                transform.position += movement;
                //_rb.AddForce(movement * MoveSpeed);
                _currentAnimator.SetBool("isMoving", true);
                _isMovingAnimation = true;
            }
        if (Input.GetKey(MoveLeft))
            {
                Vector3 movement = new Vector3(0.0f, 0.0f, 0.1f);
                transform.position += movement;
                //_rb.AddForce(movement * MoveSpeed);
                _currentAnimator.SetBool("isMoving", true);
                _isMovingAnimation = true;
            }
        if (Input.GetKey(MoveRight))
            {
                Vector3 movement = new Vector3(0.0f, 0.0f, -0.1f);
                transform.position += movement;
                //_rb.AddForce(movement * MoveSpeed);
                _currentAnimator.SetBool("isMoving", true);
                _isMovingAnimation = true;
        }

        if (!_isMovingAnimation && _currentAnimator.GetBool("isMoving") == true)
            {
                _currentAnimator.SetBool("isMoving", false);                
            }
        _isMovingAnimation = false;
    }
    private void JumpLogic()
    {
        if (Input.GetKey(Jump))
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }
    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }
    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
