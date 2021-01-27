using UnityEngine;

namespace Controllers {
    public class ArrowController : MonoBehaviour {
        private Transform arrowControllerTransform;
        [SerializeField] private GameObject arrowPrefab = default;
        [SerializeField] private Transform arrowsParent = default;
        [SerializeField] private float spawnForceModifier = 1f;

        private void Awake() {
            arrowControllerTransform = transform;
        }

        public void SpawnArrow()
        {
            GameObject spawnedArrow =
                Instantiate(arrowPrefab, arrowControllerTransform.position, arrowControllerTransform.rotation * Quaternion.Euler(0,90,0), arrowsParent);
            spawnedArrow.GetComponent<Rigidbody>().AddForce(arrowControllerTransform.forward * spawnForceModifier);
        }
    }
}