using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInteract : Interactable
{
    private Rigidbody _rigidbody;
    private Outline _outline;
    public bool isGrabbed = false;
    [SerializeField] private Transform toolTip;
    [SerializeField] private Transform cubeTransform;
    private FixedJoint _grabJoint = null;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _outline = transform.GetComponent<Outline>();
        isInteractable = false;
    }

    void Grab()
    {
        isGrabbed = true;
        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
        _rigidbody.isKinematic = true;
        
        cubeTransform.parent = toolTip;
        _grabJoint = toolTip.gameObject.AddComponent<FixedJoint>();
        _grabJoint.breakForce = 10000f; // Play with this value
        _grabJoint.connectedBody = _rigidbody;
    }
    
    void Drop()
    {
        isGrabbed = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _rigidbody.freezeRotation = false;
        cubeTransform.parent = null;
         
        Destroy(_grabJoint);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            if(Input.GetMouseButtonUp(1)) Drop();
        }
        else
        {
            if (isInteractable)
            {
                _outline.OutlineWidth = 10f;
                if (Input.GetMouseButtonUp(1)) Grab();
            }
            else _outline.OutlineWidth = 0f;
        }
    }
}
