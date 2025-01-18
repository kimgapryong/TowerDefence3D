using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpwanEnemy : MonoBehaviour
{
    public GameObject enemy;
    public RandomTileCreate randTile;
    public List<RandomTileCreate.Tilemap> posList;
    public MonsterScriptable datas;
    public UI_Monster uI_Monster;

    // 적 생성 가능한 bool
    public bool isEnemy = true;
    private float time;
    private void Start()
    {
        //적의 위치 구하기
        randTile = MapManager.Instance.randTile;
        posList = randTile.enemy;

        uI_Monster = GameObject.Find("Monster_UI(Clone)").GetComponent<UI_Monster>();
    }

    //오브젝트 상태 초기화
    void CreateEnemy(int value)
    {
        GameObject clone = Instantiate(enemy, transform.position + new Vector3(0, 2,0), Quaternion.identity);
        uI_Monster.CreateEnemy_UI(clone);
        FindPathEnemy findPath = clone.AddComponent<FindPathEnemy>();
        findPath.InitEnemyData(randTile.tiles, randTile.x, randTile.z, randTile.startX, randTile.startZ, datas);
        //A* 길찾기 리스트 초기화
        findPath.Astar(posList[value].pos.x, posList[value].pos.z);
        StartCoroutine(findPath.MoveAlongPath(0, clone));

    }

    int GetActiveCount()
    {
        int activeCount = 0;
        foreach (RandomTileCreate.Tilemap tile in posList)
        {
            if (tile.obj.activeSelf)
            {
                activeCount++;
            }
        }
        return activeCount;
    }
    float GetRandomTime()
    {
        //Debug.Log("랜덤범위 설정");
        return Random.Range(6, 11);
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= GetRandomTime() && isEnemy)
        {
            //isEnemy = false; //적 하나만 생성
            CreateEnemy(Random.Range(0,GetActiveCount()));
            time = 0;
        }
    }
}
