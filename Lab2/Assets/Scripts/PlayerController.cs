using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ArrowController arrowController =default;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform bowObject;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 0.2f;
    private bool groundedPlayer;
    private Vector3 jumpVelocity;
    
    private float gravityValue = -9.81f;
    private float chargeTime = 0f;
  
    // Update is called once per frame
    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 walk = transform.right * X + transform.forward * Z;
        
        // Stop falling when grounded
        if (groundedPlayer && jumpVelocity.y < 0) jumpVelocity.y = 0f;
        
        controller.Move(walk * (Time.deltaTime * speed));
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            jumpVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        jumpVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(jumpVelocity * (speed * Time.deltaTime));

        fireArrow();
    }

    private void fireArrow()
    {
        if (Input.GetAxis("Fire1") != 0)
        {
            chargeTime += Time.deltaTime * 500;
            chargeTime = Mathf.Clamp(chargeTime, 20, 700);
            
            bowObject.localScale = new Vector3(0.3f + chargeTime/800f,0.5f,0.5f);
            bowObject.localRotation = Quaternion.Euler(-50f - (40f * chargeTime/700f) ,0f,90f);
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            arrowController.SpawnArrow(chargeTime);
            chargeTime = 0;
            bowObject.localScale = new Vector3(0.3f,0.5f,0.5f);
            bowObject.localRotation = Quaternion.Euler(-50f,0f,90f);
        }
    }
}
