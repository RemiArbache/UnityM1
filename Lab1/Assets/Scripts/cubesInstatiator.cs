using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesInstatiator : MonoBehaviour
{
    private Transform cubesHolder;
    [SerializeField] private float  speed = 0.05f;
    [SerializeField] private GameObject cubePrefab;
    
    
    private int lastNumberOfPoints;
    private float lastRadius;
    [SerializeField] private int numberOfPoints = 200;
    [SerializeField] private float radius = 2f;
    private Quaternion lastAngle;

    
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfPoints = 200;
        speed = 0.05f;
        cubesHolder = transform;
        StartCoroutine(UpdateCubes());
    }

    private void Update()
    {
        // Rotate all the cubes 
        foreach (Transform child in cubesHolder)
        {
            GameObject cube = child.gameObject;
            cube.transform.Rotate(speed, speed, speed);
        }
        
        // Remember the cubes' angle
        if(cubesHolder.childCount != 0) lastAngle = cubesHolder.GetChild(cubesHolder.childCount - 1).transform.rotation;
    }

    private IEnumerator UpdateCubes()
    {
        while (true)
        {
            //Executes every 0.1s regardless of frame timing
            yield return new WaitForSeconds(0.1f);

            List<Vector3> circlePoints = GetCirclePoints();

            
            // If one of the attributes changes, re-instantiate the cubes 
            if (numberOfPoints != lastNumberOfPoints || radius != lastRadius)
            {
                // Delete the old cubes
                foreach (Transform child in cubesHolder) Destroy(child.gameObject);

                // Instantiate the new cubes using the angle kept in memory (lastAngle)
                // Allows for smooth animations through changes
                foreach (Vector3 circlePoint in circlePoints) Instantiate(cubePrefab, circlePoint, lastAngle, cubesHolder);
                
            }
            
            lastNumberOfPoints = numberOfPoints;
            lastRadius = radius;
        }
    }
    
    private List<Vector3> GetCirclePoints()
    {
        List<Vector3> circlePoints = new List<Vector3>();

        for (int i = 0; i < numberOfPoints; i++)
        {
            float rad = 2 * Mathf.PI * i / numberOfPoints;
            circlePoints.Add(new Vector3(
                radius * Mathf.Cos(rad),
                radius * Mathf.Sin(rad),
                0));
        }

        return circlePoints;
    }
    
}
