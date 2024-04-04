using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimating : MonoBehaviour
{
    public enum Animations
    {
        Run
    }
    private void Start()
    {
        EventManager.Instance.OnGameStart += Event_ActivateAnimation;
        
        GetComponent<PlayerManager>().OnMakeStickman += Event_ActivateAnimation;
    }


    private void Event_ActivateAnimation()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("OtherObj")) continue;

            var tempAnimator = transform.GetChild(i).GetComponent<Animator>();
            
            tempAnimator.SetBool(Animations.Run.ToString(), true);
        }
    }
}
