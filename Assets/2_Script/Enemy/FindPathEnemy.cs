using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPathEnemy : MonoBehaviour
{
    private RandomTileCreate randTile;
    RandomTileCreate.Tilemap[,] tilemaps;

    private void Start()
    {
        randTile = MapManager.Instance.randTile;
        tilemaps = MapManager.Instance.randTile.tiles;
    }

    void Astar()
    {

    }
}
