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

    //나중에 점수 매니저때 델리게이트 만들기

    public RandomTileCreate randTile = null;
    public MonsterScriptable[] datas; // 몬스터 데이터
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
        randTile.InitCreateEnemy(gameObjects, datas);

    }
}
