using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    protected Button _button;
    protected Vector3 upScale = new Vector3(1.2f, 1.2f, 1f);

    protected void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Anim);
    }

    protected void Anim()
    {
        transform.DOScale(upScale, 0.1f);
        transform.DOScale(Vector3.one, 0.1f).SetDelay(0.1f);
    }
}
