using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private GameObject _soundManager;
    [SerializeField] private GameObject _musicManager;

    private bool State = true;

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
}
