using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class rozpoczecie : MonoBehaviour
{

    public GameObject baner;

    public void rozpocznij()
    {
        gameObject.SetActive(false);
        baner.GetComponent<InicjalBaner>().bannerView.Destroy();
    }
}
