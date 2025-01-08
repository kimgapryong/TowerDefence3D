using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sentX;
    public float sentY;

    public Transform orientation;
    public Transform plaDefault;

    float xRotation;
    float yRotation;

    private void Update()
    {
        //오른쪽 클릭시 카메라 회전 
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //왼쪽 클릭시 카메라 회전 멈춤
        if(Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //커서 확인하여 카메라 회전 적용
       if(!Cursor.visible)
        {
            MoveMouse();
        }
    }

    void MoveMouse()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sentX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sentY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //yRotation = Mathf.Clamp(yRotation, -140f, -40f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        plaDefault.rotation = Quaternion.Euler(0, yRotation + 90, 0);
    }
}
