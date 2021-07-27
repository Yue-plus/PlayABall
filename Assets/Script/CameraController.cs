using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 相机控制器
public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 m_Offset;

    private void Start()
    {
        m_Offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + m_Offset;
    }
}
