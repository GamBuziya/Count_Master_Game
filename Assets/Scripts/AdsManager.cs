using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public InitializeAds InitAds;
    public BannerAds BanAds;
    public InterstitialAds InterAds;
    public RewardedAds RewardedAds;

    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        BanAds.LoadBannerAd();
        InterAds.LoadInterstitialAds();
        RewardedAds.LoadRewardedAds();

        StartCoroutine(DisplayBannerWithDelay());
        
    }

    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        BanAds.ShowBannedAd();
    }
}
