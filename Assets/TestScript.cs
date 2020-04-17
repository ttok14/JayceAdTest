using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class TestScript : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-9091492788862817~2254489756";

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;

    private void Start()
    {
        // 실제 앱 출시시 
        // MobileAds.Initialize(APP_ID);

        RequestBanner();
        RequestIntersititial();
        RequestVideoAD();
    }

    void RequestBanner()
    {
        // 실제 ca-app-pub-9091492788862817/9467653415
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        // 실제 출시할때 
        //AdRequest adReq = new AdRequest.Builder().Build();

        // TEST 
        AdRequest adReq = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
            .Build();

        bannerAD.LoadAd(adReq);
    }

    void RequestIntersititial()
    {
        // 실제 ca-app-pub-9091492788862817/7838629557 
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitial_ID);

        // 실제 출시할때 
        //AdRequest adReq = new AdRequest.Builder().Build();

        // TEST 
        AdRequest adReq = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
            .Build();

        interstitialAd.LoadAd(adReq);
    }

    void RequestVideoAD()
    {
        // 실제 ca-app-pub-9091492788862817/7987050788
        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        // 실제 출시할때 
        //AdRequest adReq = new AdRequest.Builder().Build();

        // TEST 
        AdRequest adReq = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
            .Build();

        rewardVideoAd.LoadAd(adReq, video_ID);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Display_InterstitialAD()
    {
        if(interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void Display_VideoAD()
    {
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }

    ////// 이벤트 핸들링 
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        // 광고 로딩댐 보여주자 
        Display_Banner();
    }

    public void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // 광고 로딩 실패 . 다시 req 
        RequestBanner();
    }

    public void OnAdOpened(object sender, System.EventArgs args)
    {
        // Code to be executed when an ad opens an overlay that
        // covers the screen.
    }

    public void OnAdClicked(object sender, System.EventArgs args)
    {
        // Code to be executed when the user clicks on an ad.

    }

    public void OnAdLeftApplication(object sender, System.EventArgs args)
    {
        // Code to be executed when the user has left the app.
    }
    
    public void OnAdClosed(object sender, System.EventArgs args)
    {
        // Code to be executed when the user is about to return
        // to the app after tapping on an ad.
    }

    void HandlerBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            bannerAD.OnAdLoaded += OnAdLoaded;
            bannerAD.OnAdFailedToLoad += OnAdFailedToLoad;
            bannerAD.OnAdOpening += OnAdOpened;
            bannerAD.OnAdClosed += OnAdClosed;
            bannerAD.OnAdLeavingApplication += OnAdLeftApplication;
        }
        else
        {
            bannerAD.OnAdLoaded -= OnAdLoaded;
            bannerAD.OnAdFailedToLoad -= OnAdFailedToLoad;
            bannerAD.OnAdOpening -= OnAdOpened;
            bannerAD.OnAdClosed -= OnAdClosed;
            bannerAD.OnAdLeavingApplication -= OnAdLeftApplication;
        }
    }

    private void OnEnable()
    {
        HandlerBannerADEvents(true);
    }

    private void OnDisable()
    {
        HandlerBannerADEvents(false);
    }
}
