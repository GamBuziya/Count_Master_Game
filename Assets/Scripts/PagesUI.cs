using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PagesUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] _upTransforms;
    [SerializeField] private RectTransform[] _downTransform;
    [SerializeField] private RectTransform _pauseMenu;
    [SerializeField] private RectTransform _finishMenu;
    [SerializeField] private RectTransform _failMenu;
    [SerializeField] private Image _background;

    private void Start()
    {
        EventManager.Instance.OnStartPause += StartPause;
        EventManager.Instance.OnStartPause += EndPause;
        EventManager.Instance.OnFail += FailMenu;
        EventManager.Instance.OnFinish += FinishMenu;
    }
    
    private void StartPause()
    {
        StartPageFromeTop(_pauseMenu);
    }

    private void EndPause()
    {
        EndPageFromTop(_pauseMenu);
    }
    
    private void FinishMenu()
    {
        StartPageFromeTop(_finishMenu);
    }

    private void FailMenu()
    {
        StartPageFromeTop(_failMenu);
    }
    
    private void StartPageFromeTop(RectTransform _page)
    {
        _background.DOColor(new Color32(0, 0, 0, 180), 1f).SetUpdate(true);

        if (_downTransform.Length != 0)
        {
            foreach (var downTransform in _downTransform)
            {
                downTransform.DOAnchorPos(new Vector2(0, -750), 0.75f).SetUpdate(true);
            }
        }

        if (_upTransforms.Length != 0)
        {
            foreach (var upTransform in _upTransforms)
            {
                upTransform.DOAnchorPos(new Vector2(0, 120), 0.75f).SetUpdate(true);
            }
        }
        
        _page.DOAnchorPos(new Vector2(0, 0), 1f)
            .OnComplete(() => SoundManager.Instance.PlayUITransformSound()).SetUpdate(true);
    }
    private void EndPageFromTop(RectTransform page)
    {
        _background.DOColor(new Color32(0, 0, 0, 0), 1f).SetUpdate(true);

        if (_upTransforms.Length != 0)
        {
            foreach (var upTransform in _upTransforms)
            {
                upTransform.DOAnchorPos(new Vector2(0, -130), 0.75f).SetUpdate(true);
            }
        }
        
        if (_downTransform.Length != 0)
        {
            foreach (var downTransform in _downTransform)
            {
                downTransform.DOAnchorPos(new Vector2(0, 0), 0.75f).SetUpdate(true);
            }
        }

        page.DOAnchorPos(new Vector2(1720, 0), 1f).SetUpdate(true)
            .OnComplete(() => SoundManager.Instance.PlayUITransformSound()).SetUpdate(true);
    }
    
}
