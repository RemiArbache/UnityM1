using System.Collections;
using UnityEngine;

public class SwitchInteract : Interactable
{
    private Outline _outline;
    [SerializeField] private AudioSource switchAudioSource;
    private bool _onCooldown = false;
    [SerializeField] private Activable linkedActivable;

    private void Awake()
    {
        _outline = transform.GetComponent<Outline>();
    }

    private IEnumerator PressEffect()
    {
        switchAudioSource.PlayOneShot(switchAudioSource.clip);
        linkedActivable.activated = true;
        yield return new WaitForSeconds(1f);
        linkedActivable.activated = false;
    } 

    private void Press()
    {
        StartCoroutine(PressEffect());
    }

    void Update()
    {
        if (isInteractable && !linkedActivable.activated)
        {
            _outline.OutlineWidth = 10f;
            if (Input.GetMouseButtonUp(1)) Press();
        }
        else _outline.OutlineWidth = 0f;
    }
}