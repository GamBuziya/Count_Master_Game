using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _mainMenu, _levelsChooser;

    public void LevelsChooserButton()
    {
        _mainMenu.DOAnchorPos(new Vector2(-1100, 0), 0.25f).SetUpdate(true);
        _levelsChooser.DOAnchorPos(new Vector2(0, 0), 0.75f).SetUpdate(true)
            .OnComplete(() => SoundManager.Instance.PlayUITransformSound()).SetUpdate(true);
    }
    
    public void MainMenuButton()
    {
        _mainMenu.DOAnchorPos(new Vector2(0, 0), 0.75f).SetUpdate(true)
            .OnComplete(() => SoundManager.Instance.PlayUITransformSound()).SetUpdate(true);
        
        _levelsChooser.DOAnchorPos(new Vector2(0, 2000), 0.25f).SetUpdate(true);
    }
}
