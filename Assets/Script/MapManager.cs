using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public Transform tileTrans;
    public RandomTileCreate randTile = null;
    
    private EnemyManager enemyManager; //적 생성 매니저
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
    private AtkManager _atk = new AtkManager();
    public static AtkManager Atk { get { return Instance._atk; } }
    //ResourcesManager 스크립트
    private ResourcesManager resource = new ResourcesManager();
    public static ResourcesManager Resources { get { return Instance.resource; } }

    //UIManager 스크립트
    private UIManager ui = new UIManager(); 
    public static UIManager Ui { get { return Instance.ui; } }  

    //플레이어 매니저
    private CreatePlayer _player  = new CreatePlayer();
    public static CreatePlayer CreatePlayer { get { return instance._player; } }

    public static GameObject Player { get { return instance._player.clone; } }
   
    private void Awake()
    {
        //BFS을 활용한 맵생성
        randTile = GetComponent<RandomTileCreate>();
        randTile.SetTile(tileTrans);
        
        //적생성 관리
        enemyManager = EnemyManager.Instance;
        enemyManager.InitEnemy(randTile);

        //플레이어 생성
        _player.InitPlayer(randTile);

        //UI 생성
        ui.CreateUI<UI_Scene>("UI");
        ui.CreateUI<UI_Monster>("Monster_UI");
       
    }
}
