using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnityId;
    [SerializeField] private string _iosAdUnityId;

    private string adUnityId;
    
    private void Awake()
    {
        #if UNITY_IOS
            adUnityId = _iosAdUnityId;
        #elif UNITY_ANDROID
            adUnityId = _androidAdUnityId;
        #endif
    }

    public void LoadInterstitialAds()
    {
        Advertisement.Load(adUnityId, this);
    }

    public void ShowInterstitiateAd()
    {
        Advertisement.Show(adUnityId, this);
        LoadInterstitialAds();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial is loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    #region ShowCallBacks

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Inter ad complete");
    }

    #endregion
    
}
