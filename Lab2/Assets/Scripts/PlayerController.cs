using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 0.2f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    
    private float gravityValue = -9.81f;
  
    // Update is called once per frame
    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * X + transform.forward * Z;
        
        // Stop falling when grounded
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;
        
        controller.Move(move * (Time.deltaTime * speed));
        
        if (move != Vector3.zero) gameObject.transform.forward = move;
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * (speed * Time.deltaTime));
    }
}
