using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : MonoBehaviour
{
   List<Hero_Data> heroData = new List<Hero_Data>();

    //영웅 등록하는
   public enum Hero
    {
        ChanyongAngel,
    }

    private void Start()
    {
        RetryHeroData();
    }
    private void RetryHeroData()
    {
        heroData = MapManager.Resources.LoadAllScriptableObjects<Hero_Data>("Data");
        SetHeroIcon();
    }
    
    private void SetHeroIcon()
    {
        string[] names = Enum.GetNames(typeof(Hero));
        for(int i =0; i < names.Length; i++)
        {
            Debug.Log(heroData[i]);
            UI_ClickHero clickHero = MapManager.Ui.CreateUI<UI_ClickHero>("Panel/IconPanel",gameObject.transform.Find("Back_UI"));
            clickHero.SetHeroData(heroData[i]);
        }
    }
}
