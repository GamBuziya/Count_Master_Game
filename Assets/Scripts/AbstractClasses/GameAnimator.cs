﻿using UnityEngine;

namespace AbstractClasses
{
    public class GameAnimator : MonoBehaviour
    {
        public enum Animations
        {
            Run
        }
        
        public void ActivateAnimation()
        {
            ChangeState(true);
        }

        public void StopAnimating()
        {
            ChangeState(false);
        }


        private void ChangeState(bool state)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).CompareTag("OtherObj")) continue;

                var tempAnimator = transform.GetChild(i).GetComponent<UnityEngine.Animator>();
            
                tempAnimator.SetBool(Animations.Run.ToString(), state);
            }
        }
        
    }
}