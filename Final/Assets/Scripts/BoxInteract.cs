using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInteract : MonoBehaviour
{

    public bool isInteractable;
    private Transform _transform;
    private Outline _outline;

    private void Awake()
    {
        _transform = transform;
        _outline = transform.GetComponent<Outline>();
        isInteractable = false;
    }

    void Interact()
    {
        Debug.Log("Interacted");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isInteractable)
        {
            _outline.OutlineWidth = 10f;
            if (Input.GetMouseButtonUp(1))
            {
                Interact();
            }
        }
        else
        {
            _outline.OutlineWidth = 0f;
        }
    }
}
