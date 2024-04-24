using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioClipRefSO _audioClipRefSO;

    private float _volume = 0.1f;
    private bool _soundOn = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (EventManager.Instance)
        {
            EventManager.Instance.OnFail += PlayFailSound;
            EventManager.Instance.OnFinish += PlayFinishSound;
        }
        
    }

    public void ChangeSoundState()
    {
        _soundOn = !_soundOn;

        if (_soundOn) _volume = 0.1f;
        else _volume = 0f;
    }

    public void PlayButtonSound()
    {
        PlaySound(_audioClipRefSO.Button);
    }

    public void PlayUITransformSound()
    {
        PlaySound(_audioClipRefSO.ChangeUI);
    }
    
    public void PlayFailSound()
    {
        PlaySound(_audioClipRefSO.Fail);
    }
    
    public void PlayFinishSound()
    {
        Debug.Log("PlayFinishSound");
        PlaySound(_audioClipRefSO.Finish);
    }
    
    public void PlayGateSound()
    {
        PlaySound(_audioClipRefSO.GateMove);
    }

    public void PlayFightSound()
    {
        PlaySound(_audioClipRefSO.Fight);
    }
    
    public void PlayKillZoneSound()
    {
        PlaySound(_audioClipRefSO.KillZone);
    }
    
    public void PlayJumpSound()
    {
        PlaySound(_audioClipRefSO.Jump);
    }
    
    private void PlaySound(AudioClip[] audioClip)
    {
        PlaySound(audioClip[Random.Range(0, audioClip.Length)]);
    }
    
    private void PlaySound(AudioClip audioClip)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, _volume);
            Time.timeScale = 0;
            return;
        }
        
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, _volume);
    }
}
