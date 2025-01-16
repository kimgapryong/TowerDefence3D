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
     
                instance = FindObjectOfType<MapManager>();

           
                if (instance == null)
                {
                    GameObject go = new GameObject("MapManager");
                    instance = go.AddComponent<MapManager>();
                   
                }
            }
            DontDestroyOnLoad(instance);
            return instance;
        }
    }

    //ResourcesManager 胶农赋飘
    private ResourcesManager resource = new ResourcesManager();
    public static ResourcesManager Resources { get { return Instance.resource; } }

    //UIManager 胶农赋飘
    private UIManager ui = new UIManager(); 
    public static UIManager Ui { get { return Instance.ui; } }  
   
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

        //UI 积己
        ui.CreateUI<UI_Scene>("UI");
    }
}
