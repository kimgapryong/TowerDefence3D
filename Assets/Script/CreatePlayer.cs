using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer
{
    private PlayerMovement playerCam;
    private MoveCamera moveCam;
    public GameObject clone;

    //플레이어의 상태 관리
    public void InitPlayer(RandomTileCreate randTile)
    {
        GameObject player = MapManager.Resources.Load<GameObject>("Prefab/Player");
        clone = Object.Instantiate(player, new Vector3(randTile.startX, 10, randTile.startZ), Quaternion.identity);

        //카메라 설정
        playerCam = Camera.main.GetComponent<PlayerMovement>();
        playerCam.orientation = clone.transform.Find("Orientation");
        playerCam.plaDefault = clone.transform.Find("Chanyong/default");

        moveCam = Camera.main.GetComponent<MoveCamera>();
        moveCam.cameraPosition = clone.transform.Find("Chanyong/default/CameraPos");
        MoveCamera.cameraDirection = clone.transform.Find("Chanyong/default/CameraPos");
    }
}
