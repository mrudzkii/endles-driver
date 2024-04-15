using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSize : MonoBehaviour
{
    public RectTransform canvas, button;

    void Start()
    {
        button.sizeDelta = new Vector2(canvas.sizeDelta.x / 2, canvas.sizeDelta.y);
    }
}
