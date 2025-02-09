using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tower : UI_SliderBase
{
    protected override void Start()
    {
        base.Start();
        slider.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 45);
        image.color = Color.green;
    }
}
