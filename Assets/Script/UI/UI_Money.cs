using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Money : UI_Base
{
    public Text mTxt;
    public enum MTxt
    {
        Money_Txt,
    }
    void Start()
    {
        Bind<Text>(typeof(MTxt));
        mTxt = Get<Text>((int)MTxt.Money_Txt);
        MapManager.Money.SetMoney_UI(this);
        MapManager.Money.Money = MoneyManager.STR_MONEY;
    }

    
}
