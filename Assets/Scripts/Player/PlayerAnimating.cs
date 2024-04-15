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
        
        GetComponent<PlayerManager>().OnMakeStickman += ActivateAnimation;
    }
    
}
