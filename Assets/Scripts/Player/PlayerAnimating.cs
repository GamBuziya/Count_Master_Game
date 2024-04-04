using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animator = AbstractClasses.Animator;

public class PlayerAnimating : Animator
{
    
    private void Start()
    {
        EventManager.Instance.OnGameStart += ActivateAnimation;
        
        GetComponent<PlayerManager>().OnMakeStickman += ActivateAnimation;
    }
    
}
