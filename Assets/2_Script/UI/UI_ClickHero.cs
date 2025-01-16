using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ClickHero : UI_Base, IPointerClickHandler
{
    Action<PointerEventData> clickEvent;
    Hero_Data data;
    enum Images
    {
        Icon,
    }
    enum Texts
    {
        MoneyTxt,
    }
    private void Start()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));  

    }
    public void SetHeroData(Hero_Data data)
    {
        this.data = data;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(clickEvent != null) 
            clickEvent.Invoke(eventData);
    }
}
