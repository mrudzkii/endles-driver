using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using TMPro;

public class ContinueRewardedAd : MonoBehaviour
{
    private InterstitialAd interstitial_Ad;
    private RewardedAd rewardedAd;

    private string interstitial_Ad_ID;
    private string rewardedAd_ID;

    public GameObject gracz, odliczanieTxt;

    void Start()
    {
        rewardedAd_ID = "ca-app-pub-3940256099942544/5224354917";

        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();

        odliczanieTxt.SetActive(false);

    }

    private void RequestRewardedVideo()
    {
        rewardedAd = new RewardedAd(rewardedAd_ID);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestRewardedVideo();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewardedVideo();
        GameObject.Destroy(gracz.GetComponent<skrecanie>().powodPrzegranej);
        Debug.Log("hajs sie zgadza B))");
        gracz.GetComponent<skrecanie>().continueButton.SetActive(false);
        gracz.GetComponent<skrecanie>().noThanks.SetActive(false);
        StartCoroutine(odliczanie());
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        RequestRewardedVideo();
    }

    IEnumerator odliczanie()
    {
        odliczanieTxt.GetComponent<TextMeshProUGUI>().text = "3...";
        odliczanieTxt.SetActive(true);
        yield return new WaitForSecondsRealtime(.01f);
        Time.timeScale = 0;
        Debug.Log("Pauza debilu");
        yield return new WaitForSecondsRealtime(1);
        odliczanieTxt.GetComponent<TextMeshProUGUI>().text = "2...";
        yield return new WaitForSecondsRealtime(1);
        odliczanieTxt.GetComponent<TextMeshProUGUI>().text = "1...";
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        odliczanieTxt.SetActive(false);
    }
}
