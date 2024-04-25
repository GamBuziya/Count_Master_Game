using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
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
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions()
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };
        
        Advertisement.Banner.Load(adUnityId, options);
    }

    public void ShowBannedAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        
        Advertisement.Banner.Show(adUnityId, options);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    #region Show CallBacks

    private void BannerHidden()
    {
        throw new System.NotImplementedException();
    }

    private void BannerClicked()
    {
        throw new System.NotImplementedException();
    }

    private void BannerShown()
    {
    }

    #endregion

    #region LoadCallBacks

    public void BannerLoadedError(string message)
    {
    }

    private void BannerLoaded()
    {
        Debug.Log("Banner Loaded");
    }

    #endregion
    
}
