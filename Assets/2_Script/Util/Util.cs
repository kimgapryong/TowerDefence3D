using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UI_Scene;

public class Util : MonoBehaviour
{
    public static T GetOrAddComponent<T>(GameObject obj) where T : Component
    {
        T component = obj.GetComponent<T>();
        if(component == null)
            component = obj.AddComponent<T>();

        return component;
    }

    //스크립터블에서 오브젝트 이름 대입해서 딕셔너리 값 넣어주기
    public static T GetDataByEnum<T>(Hero heroEnum, List<T> list) where T : Hero_Data
    {
        foreach (T data in list)
        {
            if (data.name == heroEnum) 
                return data;
        }
        return null;
    }

    //자식의 오브젝트들을 찾아주는
    public static T FindChildObj<T>(GameObject obj, string name, bool region = true) where T : Object
    {
        if(string.IsNullOrEmpty(name)) return null;

        if (!region)
        {
            for(int i = 0; i < obj.transform.childCount; i++)
            {
                Transform child = obj.transform.GetChild(i);
                if(name == child.name)
                    return child.GetComponent<T>();
            }
        }
        else
        {
            foreach (T com in obj.GetComponentsInChildren<T>())
            {
                if(com.name == name)
                    return com;
            }
        }

        return null;
    }

    //데이터 정렬

}
