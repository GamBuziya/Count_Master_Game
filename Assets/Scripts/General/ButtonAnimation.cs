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

    private SoundManager _soundManager;

    protected void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Anim);
    }

    private void Start()
    {
        GameObject effectSoundManager = GameObject.Find("EffectSoundManager");

        if (effectSoundManager == null)
        {
            //Debug.LogError("EffectSoundManager isn`t exist");
            return;
        }
        
        if (effectSoundManager.TryGetComponent(out SoundManager soundManager))
        {
            Debug.Log("OK");
            _soundManager = soundManager;
        }
        else
        {
            Debug.LogError("SoundManager component not found on EffectSoundManager GameObject.");
        }
    }

    protected void Anim()
    {
        if (_soundManager != null)
        {
            _soundManager.PlayButtonSound();
        }
        transform.DOScale(upScale, 0.1f).SetUpdate(true);
        transform.DOScale(Vector3.one, 0.1f).SetDelay(0.1f).SetUpdate(true);
    }
}
