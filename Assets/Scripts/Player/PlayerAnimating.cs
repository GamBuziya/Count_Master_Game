using System;
using System.Collections;
using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;

public class PlayerAnimating : GameAnimator
{
    
    private void Start()
    {
        EventManager.Instance.OnGameStart += ActivateAnimation;
        EventManager.Instance.OnFinish += StopAnimating;
        GetComponent<PlayerManager>().OnMakeStickman += ActivateAnimation;
    }
    
}
