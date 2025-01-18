using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHeroTile : MonoBehaviour
{
    RandomTileCreate rand;
    RandomTileCreate.Tilemap tilemap;
    private void Start()
    {
        rand = GameObject.Find("MapManager").GetComponent<RandomTileCreate>();
    }
    private void Update()
    {
        //타일에 설치
        if (Input.GetMouseButtonDown(0))
        {
            if(!(tilemap.tile == RandomTileCreate.Tile.Wall)) 
                return;

            if (!tilemap._equipped)
            {
                tilemap._equipped = true;
                PlayerMovement.ClickHero = false;
                MoveCamera.checkCam = false;
                UI_ClickHero.setHero = false;
                gameObject.transform.Find("Radious").GetComponent<MeshRenderer>().enabled = false;
                gameObject.transform.Find("Radious").GetComponent<Hero_Base>().enabled = true;
                Destroy(this); 
            }
        } 
        //취소하기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerMovement.ClickHero = false;
            MoveCamera.checkCam = false;
            UI_ClickHero.setHero = false;
            Destroy(gameObject);
        }
        FindMouseTrans();
    }
    public void FindMouseTrans()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        // Raycast로 충돌 확인
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            int x = (int)hit.transform.position.x / RandomTileCreate.MOVE;
            int z = (int)hit.transform.position.z / RandomTileCreate.MOVE;
            tilemap = rand.GetTile(x, z);
            if (tilemap != null)
                gameObject.transform.position = new Vector3(tilemap.pos.x, 1, tilemap.pos.z) * RandomTileCreate.MOVE;
            else
                gameObject.transform.position = hit.point;
        }
    }
}
