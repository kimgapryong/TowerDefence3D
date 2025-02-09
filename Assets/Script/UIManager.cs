using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    //Prefab에 있는 UI생성
    public T CreateUI<T>(string path, Transform trans = null) where T : Component
    {
        GameObject obj = MapManager.Resources.Instantiate($"UI/{path}");
        T component = Util.GetOrAddComponent<T>(obj);

        if (trans != null)
            obj.transform.SetParent(trans);

        return component;
    }

    public void EnemyBarSlider<T>(GameObject obj, float current, float max) where T : UI_SliderBase
    {
        float currentHp = current / max;
        currentHp = Mathf.Max(0, currentHp);
        T ui = Util.FindChildObj<T>(obj, "Enemy_Bar");
        
        ui.slider.value = currentHp;
    }

}
