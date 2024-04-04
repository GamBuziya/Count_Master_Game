using System;
using System.Collections;
using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : CharactersManager
{
    private void Start()
    {
        for (int i = 0; i < Random.Range(5, 100); i++)
        {
            Instantiate(_stickman, transform.position, new Quaternion(0f, 180f, 0f, 1f), transform);
        }
        
        FormatStickMan();
        _counter.text = (transform.childCount - 1).ToString();
    }
    
}
