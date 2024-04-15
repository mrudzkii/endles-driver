using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    public Text tekst;

    void Update()
    {
        tekst.text = (1.0f / Time.deltaTime).ToString();
    }
}
