using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private Transform toolTip;
    
    // Using "camera" hides an existing Component
    // ReSharper disable once InconsistentNaming
    [SerializeField] private Camera _camera;
    private Transform _transform;
    private Transform _cameraTransform;
    private bool _hitSomething = false;
        

    [SerializeField] private float maxRange;

    private void Awake()
    {
        _transform = transform;
        _cameraTransform = _camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        
        Interactable lastSeen = null;
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * 10000f, Color.red);
        
        if (Physics.Raycast(ray, out hit, maxRange) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            switch (hit.transform.gameObject.tag)
            {
                case "CubeInteractable":
                {
                    lastSeen = hit.transform.gameObject.GetComponent<BoxInteract>();
                    lastSeen.isInteractable = true;
                    _hitSomething = true;
                    break;
                }
                case "SwitchInteractable":
                {
                    lastSeen = hit.transform.gameObject.GetComponent<SwitchInteract>();
                    lastSeen.isInteractable = true;
                    _hitSomething = true;
                    break;
                }
            }

        }
        else if(_hitSomething)
        {
            // Null Pointer Exception impossible
            // Check by adding '  && lastSeen != null ' in if condition just above
            lastSeen.isInteractable = false;
        }
        
    }
}
