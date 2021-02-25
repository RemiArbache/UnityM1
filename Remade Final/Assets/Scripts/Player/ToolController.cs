using System;
using System.Collections;
using System.Collections.Generic;
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
    Interactable _lastSeen = null;

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
        
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * 10000f, Color.red);
        
        if (Physics.Raycast(ray, out hit, maxRange) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            switch (hit.transform.gameObject.tag)
            {
                case "CubeInteractable":
                {
                    _lastSeen = hit.transform.gameObject.GetComponent<BoxInteract>();
                    _lastSeen.isInteractable = true;
                    _hitSomething = true;
                    break;
                }
                case "SwitchInteractable":
                {
                    _lastSeen = hit.transform.gameObject.GetComponent<SwitchInteract>();
                    _lastSeen.isInteractable = true;
                    _hitSomething = true;
                    break;
                }
            }

        }
        else if(_hitSomething && _lastSeen != null)
        {
            // Null Pointer Exception impossible
            // Check by adding '  && lastSeen != null ' in if condition just above
            _lastSeen.isInteractable = false;
        }
        
    }
}
