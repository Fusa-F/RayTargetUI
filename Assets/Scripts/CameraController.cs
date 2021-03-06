﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Header("カメラ移動速度")] private float speed = 1f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform.parent;
    }
	
	void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        //ドラッグ中のみ
        if(Input.GetMouseButton(0))
        {
            return;
        }
        float xRotate = Input.GetAxis("Mouse X") * speed;
        float yRotate = Input.GetAxis("Mouse Y") * speed;
        // 見づらくなるので回転軸を分ける
        playerTransform.transform.Rotate(0, xRotate, 0);
        transform.Rotate(-yRotate, 0, 0);
    }
}