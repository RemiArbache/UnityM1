using UnityEngine;

namespace Controllers {
    public class ArrowController : MonoBehaviour {
        [SerializeField] private GameObject arrowPrefab = default;
        [SerializeField] private Transform arrowsParent = default;

        [SerializeField] private Transform arrowDirection;
        [SerializeField] private Transform arrowOrigin;
        
        public void SpawnArrow(float forceModifier)
        {
            GameObject spawnedArrow =
                Instantiate(arrowPrefab, arrowOrigin.position, arrowOrigin.rotation , arrowsParent);
            spawnedArrow.GetComponent<Rigidbody>().AddForce(arrowDirection.forward * forceModifier);
        }
    }
}