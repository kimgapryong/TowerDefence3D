using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager
{
    public const float STR_MONEY = 500;
    private UI_Money ui;

    private float _money;
    public float Money
    {
        get { return _money; }
        set
        {
            _money = value;
            ui.mTxt.text = value.ToString();
        }
    }

    public void SetMoney_UI(UI_Money ui)
    {
        this.ui = ui;
    }
  
}
