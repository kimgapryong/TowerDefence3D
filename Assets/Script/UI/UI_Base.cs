using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> UIData = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] enumName = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[enumName.Length];

        for(int i =0; i<enumName.Length; i++)
        {
            objects[i] = Util.FindChildObj<T>(gameObject, enumName[i]);
        }
        UIData.Add(typeof(T), objects);
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;

        if(UIData.TryGetValue(typeof(T), out objects))
            return objects[idx] as T;

        return null;
    }

}
