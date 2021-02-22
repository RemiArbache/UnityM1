using System.Collections;
using UnityEngine;

public class SwitchInteract : Interactable
{
    private Outline _outline;
    [SerializeField] private AudioSource switchAudioSource;
    private bool _onCooldown = false;
        
    private void Awake()
    {
        _outline = transform.GetComponent<Outline>();
    }

    private IEnumerator PressEffect()
    {

        switchAudioSource.Play();
        _onCooldown = true;
        yield return new WaitForSeconds(1f);
        _onCooldown = false;

    } 

    private void Press()
    {
        StartCoroutine (PressEffect());
            
    }

    void Update()
    {
        if (isInteractable && !_onCooldown)
        {
            _outline.OutlineWidth = 10f;
            if (Input.GetMouseButtonUp(1)) Press();
        }
        else _outline.OutlineWidth = 0f;
    }
}