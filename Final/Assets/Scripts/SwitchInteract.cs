using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SwitchInteract : Interactable
    {
        private Outline _outline;
        [SerializeField] private AudioSource switchAudioSource;
        private bool onCooldown = false;
        
        private void Awake()
        {
            _outline = transform.GetComponent<Outline>();
        }

        private IEnumerator pressEffect()
        {

            switchAudioSource.Play();
            onCooldown = true;
            yield return new WaitForSeconds(1f);
            onCooldown = false;

        } 

        private void press()
        {
            StartCoroutine (pressEffect());
            
        }

        void Update()
        {
            if (isInteractable && !onCooldown)
            {
                _outline.OutlineWidth = 10f;
                if (Input.GetMouseButtonUp(1)) press();
            }
            else _outline.OutlineWidth = 0f;
        }
    }
}