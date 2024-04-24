using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private GameObject _soundManager;
    [SerializeField] private GameObject _musicManager;

    private bool State = true;

    private void Start()
    {
        EventManager.Instance.OnFinish += MusicOff;
        EventManager.Instance.OnFail += MusicOff;
    }

    
    public void ChangeSoundState()
    {
        State = !State;
        if (_soundManager.TryGetComponent(out SoundManager soundManager))
        {
            soundManager.ChangeSoundState();
        }
        else
        {
            Debug.LogWarning("SoundManager isn`t correct");
        }
        _musicManager.SetActive(State);
    }

    private void MusicOff()
    {
        _musicManager.SetActive(false);
    }
}
