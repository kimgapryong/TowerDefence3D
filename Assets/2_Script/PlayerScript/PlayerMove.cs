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
    private bool isGround;
    public LayerMask layer;

    private Transform playerBody;
    private Transform rotateChayong;
    private Rigidbody rb;

    float horizontal;
    float vertical;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        playerBody = transform.Find("Chanyong/default");
        rotateChayong = transform.Find("Orientation");
    }
    private void Update()
    {
        PlayerInput();

        //레이케스트 위치에서 점프가 잘 안잡힘
        isGround = Physics.Raycast(playerBody.position, Vector3.down, 0.4f, layer);

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
    private void OnDrawGizmos()
    {
        if (playerBody != null)
        {
            // 레이캐스트의 경로를 시각화
            float raycastDistance = 0.3f;
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(playerBody.position, playerBody.position + Vector3.down * raycastDistance);
        }
    }

}
