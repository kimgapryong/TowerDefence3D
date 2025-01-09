using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public Transform tileTrans;
    public RandomTileCreate randTile = null;

    private EnemyManager enemyManager; //利 积己 概聪历
    CreatePlayer createPlayer = null;
    SpwanEnemy spwanEnemy = null;
    
    private static MapManager instance;
    public static MapManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("MapManager");
                instance = go.AddComponent<MapManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        //BFS阑 劝侩茄 甘积己
        randTile = GetComponent<RandomTileCreate>();
        randTile.SetTile(tileTrans);
        
        //利积己 包府
        enemyManager = EnemyManager.Instance;
        enemyManager.InitEnemy(randTile);

        //敲饭捞绢 积己
        createPlayer = GetComponent<CreatePlayer>();
        createPlayer.InitPlayer(randTile);
    }
}
