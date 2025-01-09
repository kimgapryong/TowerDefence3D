using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class FindPathEnemy : MonoBehaviour
{
    RandomTileCreate.Tilemap[,] tilemaps;
    //몬스터의 데이터
    public MonsterScriptable data;

    //부모의 Tilemap을 담을 리스트
    public List<RandomTileCreate.Tilemap> tileList;

    //맵의 크기
    private int xValue;
    private int zValue;

    //맵의 중아 지점
    private int endX;
    private int endZ;
    struct PQnode : IComparable<PQnode>
    {
        public int F;
        public int G;
        public int X;
        public int Z;

        public int CompareTo(PQnode other)
        {
            if (F == other.F) return 0;
            return F < other.F ? -1 : 1;    
        }
    }
    //캐릭터의 객체 초기화
    public void InitEnemyData(RandomTileCreate.Tilemap[,] tilemap, int x, int z, int endX, int endZ, MonsterScriptable data)
    {
        tilemaps = tilemap;
        tileList = new List<RandomTileCreate.Tilemap>();

        xValue = x;
        zValue = z;

        this.endX = endX;
        this.endZ = endZ;
        this.data = data;
    }
    public void Astar(int strX, int strZ)
    {
        Debug.Log("dd");
        int[] deltaX = new int[4] { 1, 0, -1, 0 };
        int[] deltaZ = new int[4] { 0, -1, 0, 1 };

        bool[,] closed = new bool[xValue, zValue];
        int[,] open = new int[xValue, zValue];
        RandomTileCreate.Tilemap[,] parent = new RandomTileCreate.Tilemap[xValue, zValue];
        Heap<PQnode> pqHeap = new Heap<PQnode>();

        // 초기화
        for (int x = 0; x < xValue; x++)
        {
            for (int z = 0; z < zValue; z++)
            {
                open[x, z] = int.MaxValue;
            }
        }
        Debug.Log("현재 Value값 " + xValue + " " + zValue);
        Debug.Log("현재 str위치 " + strX + " " + strZ);

        // 시작 지점 설정
        open[strX, strZ] = Math.Abs(endX - strX) + Math.Abs(endZ - strZ);
        pqHeap.Push(new PQnode { F = open[strX, strZ], G = 0, X = strX, Z = strZ });
        parent[strX, strZ] = tilemaps[strX, strZ];
        Debug.Log("ㅁㅁㅁㅁㅁㅁ");
        while (pqHeap.Count > 0)
        {
            
            PQnode pq = pqHeap.Pop();

            if (closed[pq.X, pq.Z]) continue;
            closed[pq.X, pq.Z] = true;

            // 목표 지점에 도달하면 종료
            if (pq.X == endX && pq.Z == endZ) break;

            for (int i = 0; i < deltaX.Length; i++)
            {
                int nextX = pq.X + deltaX[i];
                int nextZ = pq.Z + deltaZ[i];

                // 맵의 범위를 벗어나면 스킵
                if (nextX < 0 || nextZ < 0 || nextX >= xValue || nextZ >= zValue) continue;

                // 벽인 경우 스킵
                if (tilemaps[nextX, nextZ].tile == RandomTileCreate.Tile.Wall) continue;

                // 이미 closed에 있으면 스킵
                if (closed[nextX, nextZ]) continue;

                int g = pq.G + 1;
                int h = Math.Abs(endX - nextX) + Math.Abs(endZ - nextZ);
                int f = g + h;

                // open 배열 값이 더 작으면 경로가 더 효율적이지 않다는 뜻이므로 스킵
                if (open[nextX, nextZ] < f) continue;

                open[nextX, nextZ] = f;
                pqHeap.Push(new PQnode() { F = f, G = g, X = nextX, Z = nextZ });
                parent[nextX, nextZ] = tilemaps[pq.X, pq.Z];
            }
        }

        CalcPathFromParent(parent);
    }

    // A*의 리스트를 거꾸로 바꾸는 코드
    void CalcPathFromParent(RandomTileCreate.Tilemap[,] parent)
    {
        int destX = endX;
        int destZ = endZ;

        
        while(parent[destX, destZ].pos.x != destX || parent[destX,destZ].pos.z != destZ)
        {
            tileList.Add(parent[destX, destZ]);

            destX = parent[destX,destZ].pos.x;
            destZ = parent[destX, destZ].pos.z;
        }
        tileList.Add(parent[destX, destZ]);
        tileList.Reverse();
    }

    public IEnumerator MoveAlongPath(int currentIndex, GameObject obj)
    {
        if (currentIndex >= tileList.Count - 1)
        {
            yield break; // 경로 끝에 도달
        }

        RandomTileCreate.Tilemap currentTile = tileList[currentIndex];
        RandomTileCreate.Tilemap nextTile = tileList[currentIndex + 1];

        if (currentTile.obj != null && nextTile.obj != null)
        {
     
            Vector3 start = obj.transform.position;
            Vector3 end = nextTile.obj.transform.position;

            float distance = Vector3.Distance(start, end);
            float elapsedTime = 0f;

            while (elapsedTime < 1f) // elapsedTime이 1까지 진행되면 경로 끝에 도달
            {
                // elapsedTime을 Lerp의 비율로 사용
                obj.transform.position = Vector3.Lerp(start, end, elapsedTime);
                elapsedTime += Time.deltaTime / (distance / data.speed); // 속도에 맞게 증가
                yield return null; // 다음 프레임까지 대기
            }

            // 최종 위치 조정 (누락된 부분 보정)
            obj.transform.position = end;

            // 다음 노드로 재귀 호출
            yield return StartCoroutine(MoveAlongPath(currentIndex + 1, obj));
        }
    }

}
