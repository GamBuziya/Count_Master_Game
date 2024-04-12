using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogWithSpikesManager : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Швидкість обертання

    // Викликається на кожному кадрі
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        
        
        float newZRotation = currentRotation.z + rotationSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, newZRotation);
    }
}
