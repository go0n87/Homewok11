using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.GlobalStringVars
{
    [RequireComponent(typeof(BallMovement))]
    public class BallController : MonoBehaviour
    {
        public float JumpForce;
        private Vector3 _movement;      
        private bool _isGrounded;
        private BallMovement _ballMovement;
        private float _jump;

        void Start()
        {
            _ballMovement = GetComponent<BallMovement>();
        }
        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            _jump = Input.GetAxis(GlobalStringVars.JUMP_BUTTON);
            _movement = new Vector3(vertical, 0, -horizontal).normalized;
        }
        private void FixedUpdate()
        {
            _ballMovement.MovementLogic(_movement);
            _ballMovement.JumpLogic(_jump, _isGrounded);
        }
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = false;
            }
        }
        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == ("Ground") && !_isGrounded)
            {
                _isGrounded = true;
            }
        }
    }
}
