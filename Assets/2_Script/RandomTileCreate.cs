
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.GraphView;
using System;

[Serializable]
public class Pos
{
    public int x;
    public int z;
    public Pos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}
public class RandomTileCreate : MonoBehaviour
{
    public class Tilemap
    {        
        public Pos pos;
        public GameObject obj;
        public Tile tile;

        public bool _equipped = false;
      
        public Tilemap(Tile tile, Pos pos, GameObject obj = null)
        {
            this.obj = obj;
            this.tile = tile;
            this.pos = pos;
        }
        //오브젝트를 만들고 넣어주는 함수
        public void UpdateObject(GameObject newObject)
        {
            obj = newObject;
        }
        //무슨 타일인지 업데이트 해주는 함수
        public void UpdateTile(Tile tile)
        {
            this.tile = tile;
        }

 
    }
    public GameObject[] tile;
    
    //적 생성하는 위치의 노드
    public List<Tilemap> enemy = new List<Tilemap>();
    public const int MOVE = 2;

    public int x = 26;
    public int z = 26;

    public int startX;
    public int startZ;
    public enum Tile
    {
        Empty = 0,
        Wall = 1,
        Start = 2,
    }
    public Tilemap[,] tiles;

    public void SetTile(Transform trans)
    {
        tiles = new Tilemap[x,z];
        SetTileType();
        CreateTile(trans);
    }
    void SetTileType()
    {
        for(int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                tiles[i, j] = new Tilemap(Tile.Wall, new Pos(i,j));
            }
        }

        startX = x / 2;
        startZ = z / 2;

        //만약 적을 많이 처치했다면 실행

        int endX = 0;
        int endZ = 0;

        // 적 생성 기지 생성
        for (int i = 0; i < 10; i++)
        {
            int rand = UnityEngine.Random.Range(0, 2);
            if (rand == 0)
            {
                endZ = UnityEngine.Random.Range(0, z - 1);
                int ran = UnityEngine.Random.Range(0, 2);
                if (ran == 0)
                    endX = 0;
                else
                    endX = x - 1;

            }
            else
            {
                endX = UnityEngine.Random.Range(0, x - 1);
                int ran = UnityEngine.Random.Range(0, 2);
                if (ran == 0)
                    endZ = 0;
                else
                    endZ = z - 1;
            }
            enemy.Add(GetTile(endX, endZ));
            FindEmpty(endX, endZ, startX, startZ);
        }
       
    }

    //BFS을 활용한 맵생성
    //맵을 생성시 자꾸 대각선으로 생성될 때가 있음
    void FindEmpty(int strX, int strZ, int endX, int endZ)
    {
        Queue<Pos> queue = new Queue<Pos>();
        bool[,] visited = new bool[x,z];
        Pos[,] parent = new Pos[x,z];

        int[] deltaX = new int[] { 1, 0, -1, 0 };
        int[] deltaZ = new int[] { 0, -1, 0, 1 };

        queue.Enqueue(new Pos(strX, strZ));
        parent[strX, strZ] = new Pos(strX, strZ);
        visited[strX, strZ] = true;


        while (queue.Count > 0)
        {
            Pos now = queue.Dequeue();

            int nextX = 0;
            int nextZ = 0;


            List<int> randIdx = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                randIdx.Add(i);

            }

            var random = new System.Random();
            randIdx = randIdx.OrderBy(x => random.Next()).ToList();

            foreach (int i in randIdx)
            {
                nextX = now.x + deltaX[i];
                nextZ = now.z + deltaZ[i];

                if (nextX < 0 || nextZ < 0 || nextX >= x || nextZ >= z) continue;
                if (visited[nextX, nextZ]) continue;

              
                parent[nextX, nextZ] = now;
                visited[nextX, nextZ] = true;
                queue.Enqueue(new Pos(nextX, nextZ));

            }
            if (nextZ == endZ && nextX == endX) break;
        }

        int nowX = endX;
        int nowZ = endZ;

        while (parent[nowX, nowZ].x != nowX || parent[nowX,nowZ].z != nowZ)
        {
            int nextX = nowX;
            int nextZ = nowZ;
            Debug.LogWarning(string.Format("Update Tile Called : ({0},{1})", nowX, nowZ));
            tiles[nowX, nowZ].UpdateTile(Tile.Empty);
            nowX = parent[nextX, nextZ].x;
            nowZ = parent[nextX, nextZ].z;
        }
        Debug.LogWarning(string.Format("Update Tile Called : ({0},{1})", nowX, nowZ));
        tiles[nowX, nowZ].UpdateTile(Tile.Start);
    }
    void CreateTile(Transform trans)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject obj = Instantiate(tile[(int)tiles[i, j].tile], new Vector3(i * MOVE, 0, j * MOVE), Quaternion.identity);
                obj.transform.SetParent(trans);
                obj.transform.Find("default").AddComponent<BoxCollider>();
                obj.transform.Find("default").gameObject.tag = "Ground";
                obj.transform.Find("default").gameObject.layer = LayerMask.NameToLayer("Ground");
                tiles[i,j].UpdateObject(obj.transform.Find("default").gameObject);

            }
        }
    }

    //타일 구하기
    public Tilemap GetTile(int x, int z)
    {
        return tiles[x,z];
    }

    //초반 적생성 오브젝트 초기화
    public void InitCreateEnemy(GameObject[] objects, MonsterScriptable[] datas)
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            SpwanEnemy spwan = enemy[i].obj.AddComponent<SpwanEnemy>();
            if(i < objects.Length)
            {
                spwan.enemy = objects[i];
                spwan.datas = datas[i];
            }

            

            enemy[i].obj.SetActive(false);
        }
        enemy[0].obj.SetActive(true);
    }
}
