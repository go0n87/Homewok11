using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.GlobalStringVars
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] public float MoveSpeed = 2.0f;
        [SerializeField, Range(0, 100)] public float JumpForce = 100.0f;
        
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        public void MovementLogic(Vector3 movement)
        {
            _rb.AddForce(movement * MoveSpeed);
        }
        public void JumpLogic(float Jump, bool _isGrounded)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * Jump * JumpForce);
            }
        }
#if UNITY_EDITOR
        [ContextMenu("Reset speed values")]
        public void ResetSpeedValues()
        {
            MoveSpeed = 2.0f;
        }
#endif
    }
}
