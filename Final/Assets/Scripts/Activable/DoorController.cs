using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Audio;

public class DoorController : Activable
{
    [SerializeField] private Animator leftAnimator;
    [SerializeField] private Animator rightAnimator;
    [SerializeField] private AudioSource doorAudioSource;

    private bool lastState;

    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    
    private void Start()
    {
        lastState = activated;
    }

    IEnumerator PlayCloseClip()
    {
        doorAudioSource.clip = closeClip;
        doorAudioSource.Play();
        yield return new WaitForSeconds(doorAudioSource.clip.length);
    }
    
    IEnumerator PlayOpenClip()
    {
        doorAudioSource.clip = openClip;
        doorAudioSource.Play();
        yield return new WaitForSeconds(doorAudioSource.clip.length);
    }
    
    private void Update()
    {
        if (lastState != activated && !doorAudioSource.isPlaying)
        {
            if (activated)
            {
                StartCoroutine(PlayOpenClip());
                //PlayOpenClip();
            }
            else
            {
                StartCoroutine(PlayCloseClip());
            }
        }

        lastState = activated;
        leftAnimator.SetBool("Open", activated);
        rightAnimator.SetBool("Open", activated);
    }
}
