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
    
    public Action OnAttack;
    public void Attack()
    {
        OnAttack?.Invoke();
    }

    public Action OnFail;
    public void Fail()
    {
        OnFail?.Invoke();
    }
    
    
    public Action OnFinish;
    public void Finish()
    {
        OnFinish?.Invoke();
    }
    
    public Action OnStartPause;
    public void PauseStart()
    {
        OnStartPause?.Invoke();
    }
    
    public Action OnEndPause;
    public void PauseEnd()
    {
        OnEndPause?.Invoke();
    }
    
    public Action<string> OnLevelChange;
    public void LevelChange(string SceneName)
    {
        OnLevelChange?.Invoke(SceneName);
    }
    


    private void Awake()
    {
        Instance = this;
    }
}
