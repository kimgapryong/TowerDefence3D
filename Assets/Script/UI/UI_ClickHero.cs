using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ClickHero : UI_Base, IPointerClickHandler
{

    Hero_Data data;
    GameObject heroObj;
    Hero_Base heroATK;
    public static bool setHero;
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

        Get<Image>((int)Images.Icon).sprite = data.Icon;
        Get<Text>((int)Texts.MoneyTxt).text = data.Money.ToString();

    }
    public void SetHeroData(Hero_Data data, GameObject heroObj)
    {
        this.data = data;
        this.heroObj = heroObj;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //나중에 돈 시스템 추가
        if(!setHero)
        {
            GameObject clone = Instantiate(heroObj);

            // 히어로 데이터 설정
            Hero_Base heroBase = Util.FindChildObj<Hero_Base>(clone, "Radious");
            heroBase.setData(data);
            heroBase.enabled = false;
           
            Util.GetOrAddComponent<FindHeroTile>(clone);
            Transform radious = clone.transform.Find("Radious");
            radious.localScale = Vector3.one * data.Radious;

            PlayerMovement.ClickHero = true;
            MoveCamera.checkCam = true;
            setHero = true;
        }
      
        
    }
}
