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


    private void Awake()
    {
        Instance = this;
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
    
    private void PlaySound(AudioClip[] audioClip, float volume = 0.1f)
    {
        PlaySound(audioClip[Random.Range(0, audioClip.Length)], volume);
    }
    
    private void PlaySound(AudioClip audioClip, float volume = 0.1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }
}
