using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour
{
    private Rigidbody arrowRigidbody;
    private Transform arrowTransform;

    private void Awake()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
        arrowTransform = GetComponent<Transform>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Resistant"))
        {
            arrowRigidbody.isKinematic = true;
            arrowTransform.parent = other.transform;
        }
    }
}
