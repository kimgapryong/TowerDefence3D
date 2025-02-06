using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private Vector3 dir;
    float speed = 20;
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += dir * speed * Time.deltaTime;
    }
    public void SetDirectory(Vector3 dir)
    {
        this.dir = dir;
    }

}
