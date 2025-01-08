using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("EnemyManager");
                instance = go.AddComponent<EnemyManager>();
            }
            return instance;
        }
    }

    public RandomTileCreate randTile = null;
    public GameObject[] gameObjects; // 적 오브젝트
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    public void InitEnemy(RandomTileCreate rand)
    {
        randTile = rand;
        randTile.InitCreateEnemy(gameObjects);
    }
}
