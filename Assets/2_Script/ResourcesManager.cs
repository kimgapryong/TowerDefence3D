using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path)
    {
        GameObject obj = Load<GameObject>($"Prefab/{path}");
        if (obj == null)
            return null;

        return Object.Instantiate(obj);
    }

    //모든 스크립터블 데이터 긁어오기
    public List<T> LoadAllScriptableObjects<T>(string folderPath) where T : Object
    {
        List<T> scriptableObjects = new List<T>();
        T[] loadedObjects = Resources.LoadAll<T>(folderPath);

        foreach (T obj in loadedObjects)
        {
            Debug.Log(obj.name); 
            scriptableObjects.Add(obj);
        }
       
        return scriptableObjects;
    }
}
