using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SuperButtonController : MonoBehaviour
{
    [UsedImplicitly]
    private bool _switchActive = false;

    private readonly float _switchActivationWeight = 2f;
    
    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Default")) return;
        Debug.Log(other);
        if (other.GetComponent<Rigidbody>().mass > _switchActivationWeight) {
            _switchActive = true;
            Debug.Log("ACTIVE");
        }
        else
        {
            _switchActive = false;
        }
    }
     
    void OnTriggerExit ()
    {
        _switchActive = false;
        Debug.Log("INACTIVE");

    }
}
