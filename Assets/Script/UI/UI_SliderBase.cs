using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SliderBase : UI_Base
{
    public Slider slider;
    public Image image;
    enum Sliders
    {
        Monster_Health,
    }
    enum Images
    {
        Fill,
    }
    protected virtual void Start()
    {
        Bind<Slider>(typeof(Sliders));
        Bind<Image>(typeof(Images));

        slider = Get<Slider>((int)Sliders.Monster_Health);
        image = Get<Image>((int)Images.Fill);

        Canvas canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = transform.parent.position + Vector3.up * transform.parent.GetComponent<Collider>().bounds.size.y * 1.5f;
        transform.rotation = Camera.main.transform.rotation;

    }
}
