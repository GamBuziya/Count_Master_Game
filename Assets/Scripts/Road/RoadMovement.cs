using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private float _roadSpeed;
    
    private Transform _road;

    private void Start()
    {
        _road = GetComponent<Transform>();
    }
    

    private void Update()
    {
        if (PlayerManager.Instance.IsPlaying && !PlayerManager.Instance.IsAttacking())
        { 
            _road.Translate(-_road.forward * (Time.deltaTime * _roadSpeed));
        }
        else
        {
            _road.Translate(-_road.forward * 0);
        }
        
            
    }

    
    
}
