using System;
using UnityEngine;

public class GrillCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Destroy(other.gameObject);
        }
    }
}