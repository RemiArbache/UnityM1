using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDropperController : Activable
{
    [SerializeField] private GameObject normalCube;
    [SerializeField] private GameObject companionCube;
    [SerializeField] private GameObject aperture;
    [SerializeField] private Transform toolTip;
    private Transform _transform;
    private Vector3 CubePosition;
    private GameObject lastCube = null;

    private void Awake()
    {
        _transform = transform;
        CubePosition = _transform.position + new Vector3(-0.4f, -1f, 1f);
    }

    IEnumerator dispenseCube()
    {
        activated = false;
        aperture.SetActive(false);
        
        if (lastCube != null) Destroy(lastCube);
        GameObject cube;
        if (Random.value > 0.8) cube = companionCube;
        else cube = normalCube;

        lastCube = Instantiate(cube, CubePosition, Quaternion.identity);
        lastCube.GetComponentInChildren<BoxInteract>().toolTip = toolTip;
        
        yield return new WaitForSeconds(1f);
        
        aperture.SetActive(true);
    }
    private void Update()
    {
        if (activated)
        {
            StartCoroutine(dispenseCube());
        }
    }
}