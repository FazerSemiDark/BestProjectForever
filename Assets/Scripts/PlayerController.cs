using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce = 5f;
    public float Speed = 5f;

    private float _fallVelocity = 0f;

    private CharacterController _characterController;

    public Animator Aminations;

    private Vector3 _moveVector;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (_moveVector != Vector3.zero)
        {
            Aminations.SetBool("isRunning", true);
        }
        else
        {
            Aminations.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded == true)
        {
            _fallVelocity = -JumpForce;
            Aminations.SetBool("isJumping", true);
        }
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        if (_characterController.isGrounded) 
        {
            _fallVelocity = 0f;
            Aminations.SetBool("isJumping", false);
        }

         _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
