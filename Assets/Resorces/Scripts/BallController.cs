using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public KeyCode MoveForvard;
    public KeyCode MoveBack;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode Jump;
    public float MoveSpeed;
    public float JumpForce;

    private Animator _currentAnimator;
    private Rigidbody _rb;
    private bool _isGrounded;
    private bool _isMovingAnimation = false;
    private bool _jumpCooldown = false;
    private float _calculateTimer;
    private float _calculateTimerDelta;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentAnimator = GetComponent<Animator>();
        _calculateTimer = 0.1f;
    }
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
        _currentAnimator.SetBool("isGrounded", _isGrounded);

        if (!_isGrounded)
        {
            _currentAnimator.SetFloat("Velocity_y", _rb.velocity.y);
        }

        if (_jumpCooldown)
        {
            CalculateJumpCoolDown();
        }
    }
    private void MovementLogic()
    {
        if (Input.GetKey(MoveForvard))
        {
            Vector3 movement = new Vector3(MoveSpeed, 0.0f, 0.0f);
            transform.position += movement;
            _currentAnimator.SetBool("isMoving", true);
            _isMovingAnimation = true;
        }
        if (Input.GetKey(MoveBack))
        {
            Vector3 movement = new Vector3(-MoveSpeed, 0.0f, 0.0f);
            transform.position += movement;
            _currentAnimator.SetBool("isMoving", true);
            _isMovingAnimation = true;
        }
        if (Input.GetKey(MoveLeft))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, MoveSpeed);
            transform.position += movement;
            _currentAnimator.SetBool("isMoving", true);
            _isMovingAnimation = true;
        }
        if (Input.GetKey(MoveRight))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, -MoveSpeed);
            transform.position += movement;
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
        if (Input.GetKey(Jump) && !_jumpCooldown)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground") && !_jumpCooldown)
        {
            _isGrounded = false;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground") && !_isGrounded)
        {
            _isGrounded = true;
            _jumpCooldown = true;
            _currentAnimator.SetFloat("Velocity_y", 0f);
        }
    }
    private void CalculateJumpCoolDown()
    {
        _calculateTimerDelta += Time.deltaTime;
        if (_calculateTimerDelta >= _calculateTimer)
        {
            _jumpCooldown = false;
            _calculateTimerDelta = 0f;
        }
    }

}
