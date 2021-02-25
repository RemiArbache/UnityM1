using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SecondTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource automaticVoice;
    [SerializeField] private VoiceClipsScriptableObject voiceClipsScriptableObject;
    private bool _hasTriggered = false;
    
    [UsedImplicitly]
    private void OnTriggerEnter(Collider other)
    {
        if(_hasTriggered) return;
        _hasTriggered = true;
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            automaticVoice.clip = voiceClipsScriptableObject.voiceLines[0];
        }
        else
        {
            automaticVoice.clip = voiceClipsScriptableObject.voiceLines[2];
        }
        automaticVoice.Play();

    }
}
