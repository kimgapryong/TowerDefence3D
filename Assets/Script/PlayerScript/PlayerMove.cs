using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    public float jumpPower;

    //충돌 확인
    public bool isGround;
    public LayerMask layer;

    private Transform rotateChayong;
    private Rigidbody rb;

    float horizontal;
    float vertical;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        rotateChayong = transform.Find("Orientation");
    }
    private void Update()
    {
        PlayerInput();
      
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            JumpingPlayer();
        }
    }

    private void FixedUpdate()
    {
        ControllerPlayer();
    }
    void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    void ControllerPlayer()
    {
        Vector3 forwardDirection = rotateChayong.forward; 
        Vector3 rightDirection = rotateChayong.right; 

        // 이동 벡터를 계산 (forward: vertical, right: horizontal)
        Vector3 moveDirection = (forwardDirection * vertical + rightDirection * horizontal).normalized;

        // 이동 처리 (Rigidbody 사용)
        rb.MovePosition(transform.position + moveDirection * Time.deltaTime * speed);
    }
    void JumpingPlayer()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }


    public void SetGround(bool _isGround)
    {
        isGround = _isGround;
    }
}
