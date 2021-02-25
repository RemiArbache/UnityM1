using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{
    [SerializeField] private Activable door1, door2;
    [SerializeField] private AudioSource automaticVoice;
    [SerializeField] private VoiceClipsScriptableObject voiceClipsScriptableObject;
    private bool _hasTriggered = false;
    
    [UsedImplicitly]
    private void OnTriggerEnter(Collider other)
    {
        if(_hasTriggered) return;
        
        _hasTriggered = true;
        door1.activated = door2.activated = true;
        automaticVoice.clip = voiceClipsScriptableObject.voiceLines[0];
        automaticVoice.Play();

    }
}
