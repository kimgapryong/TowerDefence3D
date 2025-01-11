using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
            playerMove.SetGround(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            playerMove.SetGround(false);
    }
}
