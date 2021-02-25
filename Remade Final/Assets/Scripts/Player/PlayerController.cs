using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 0.2f;
    private bool groundedPlayer;
    private Vector3 jumpVelocity;
    private Transform _transform;
    
    private float gravityValue = -9.81f;

    private void Awake()
    {
        _transform  = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 walk = _transform.right * X + _transform.forward * Z;
        
        // Stop falling when grounded
        if (groundedPlayer && jumpVelocity.y < 0) jumpVelocity.y = 0f;
        
        controller.Move(walk * (Time.deltaTime * speed));
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            jumpVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        jumpVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(jumpVelocity * (speed * Time.deltaTime));
    }
    
}
