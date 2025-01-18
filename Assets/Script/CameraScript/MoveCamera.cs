using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public static Transform cameraDirection;
    public static bool checkCam = false;

    private void Update()
    {
        if (!checkCam)
            transform.position = cameraDirection.position;
        else
            transform.position = new Vector3(cameraDirection.position.x, cameraDirection.position.y + 4, cameraDirection.position.z);
    }
}
