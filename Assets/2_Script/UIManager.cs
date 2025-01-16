using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
