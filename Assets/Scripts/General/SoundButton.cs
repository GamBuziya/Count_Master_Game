using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace DefaultNamespace.General
{
    public class SoundButton : MonoBehaviour
    {
        
        private bool isWhite = true;
        
        protected Button _button;
        protected Vector3 upScale = new Vector3(1.2f, 1.2f, 1f);

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Anim);
        }
        
        private void Anim()
        {
            transform.DOScale(upScale, 0.1f);
            isWhite = !isWhite;
            
            if (isWhite)
            {
                GetComponent<Image>().DOColor(Color.white, 0.1f);
            }
            else
            {
                GetComponent<Image>().DOColor(Color.red, 0.1f);
            }
            
            transform.DOScale(Vector3.one, 0.1f).SetDelay(0.1f);
        }
    }
}