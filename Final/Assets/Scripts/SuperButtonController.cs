using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SuperButtonController : MonoBehaviour
{
    [UsedImplicitly]
    private bool _switchActive = false;

    [SerializeField] private Activable linkedActivable;

    private const float SwitchActivationWeight = 2f;

    private void OnTriggerStay (Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Default")) return;
        linkedActivable.activated = true;

    }
     
    [UsedImplicitly]
    private void OnTriggerExit(Collider other)
    {
        linkedActivable.activated = false;

    }
}
