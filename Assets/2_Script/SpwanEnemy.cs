using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    public GameObject enemy;
    public RandomTileCreate randTile;
    public List<RandomTileCreate.Tilemap> posList;

    // 적 생성 가능한 bool
    public bool isEnemy = true;
    private float time;
    private void Start()
    {
        //적의 위치 구하기
        randTile = MapManager.Instance.randTile;
        posList = randTile.enemy;
    }

    //오브젝트 상태 초기화
   
    void CreateEnemy()
    {
        Instantiate(enemy, transform.position + new Vector3(0, 3,0), Quaternion.identity);
    }

    float GetRandomTime()
    {
        //Debug.Log("랜덤범위 설정");
        return Random.Range(10, 15);
    }
    private void Update()
    {
        time += Time.deltaTime;
        //Debug.Log("Time" + time );
        if(time >= GetRandomTime() && isEnemy)
        {
            isEnemy = false; //적 하나만 생성
            Debug.Log("나 실행되고 있어");
            CreateEnemy();
            time = 0;
        }
    }
}
