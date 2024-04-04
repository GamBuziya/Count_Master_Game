using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private float _roadSpeed;
    private Transform _road;

    private bool _isPlaying;

    private void Start()
    {
        _road = GetComponent<Transform>();
        EventManager.Instance.OnGameStart += EventManager_OnGameStart;
    }
    private void Update()
    {
        if (_isPlaying)
        {
            _road.Translate(-_road.forward * (Time.deltaTime * _roadSpeed));
        }
    }


    void EventManager_OnGameStart()
    {
        _isPlaying = true;
    }
    
}