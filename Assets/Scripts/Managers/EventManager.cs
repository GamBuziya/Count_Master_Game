using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    
    public Action OnGameStart;
    public void GameStart()
    {
        OnGameStart?.Invoke();
    }


    private void Awake()
    {
        Instance = this;
    }
}
