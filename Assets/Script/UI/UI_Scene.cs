using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scene : MonoBehaviour
{
    List<Hero_Data> heroData = new List<Hero_Data>();
   
    //영웅 등록하는
    public enum Hero
    {
        ChanyongAngel,
        LegendPig,
    }
    
    private void Start()
    {
        RetrySceneData();
        
    }
    private void RetrySceneData()
    {
        heroData = MapManager.Resources.LoadAllScriptableObjects<Hero_Data>("Data");
        SetHeroIcon();
    }
    private void SetHeroIcon()
    {
        string[] names = Enum.GetNames(typeof(Hero));
        for (int i = 0; i < names.Length; i++)
        {
            UI_ClickHero clickHero = MapManager.Ui.CreateUI<UI_ClickHero>("Panel/IconPanel", gameObject.transform.Find("Back_UI"));
            GameObject obj = MapManager.Resources.Load<GameObject>($"Prefab/{names[i]}");
            clickHero.SetHeroData(heroData[i], obj);
        }
    }
}
