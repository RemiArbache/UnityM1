using System;
using UnityEngine;

public class BoxVoiceLineActivation : MonoBehaviour
{
      private Transform _transform;
      [SerializeField] public AudioSource automaticVoice;
      [SerializeField] private VoiceClipsScriptableObject voiceClipsScriptableObject;
      private bool _hasTriggered = false;

      
      private void Awake()
      {
            _transform = transform;
      }

      private void Update()
      {
            if (_transform.position.y < 10f && !_hasTriggered)
            {
                  automaticVoice.clip = voiceClipsScriptableObject.voiceLines[1];
                  automaticVoice.Play();
            }

      }
}