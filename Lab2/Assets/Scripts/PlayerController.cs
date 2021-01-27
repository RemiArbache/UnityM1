using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ArrowController arrowController =default;
    [SerializeField] private CharacterController controller;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 0.2f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    
    private float gravityValue = -9.81f;
    private float chargeTime = 0f;
  
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
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * (speed * Time.deltaTime));

        if (Input.GetAxis("Fire1") != 0) chargeTime += Time.deltaTime;
        if (Input.GetButtonUp("Fire1"))
        {
            arrowController.SpawnArrow(chargeTime * 500);
            chargeTime = 0;
        }
    }
}
