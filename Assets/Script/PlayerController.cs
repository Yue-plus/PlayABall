using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// 玩家控制器
public class PlayerController : MonoBehaviour
{
    // 移动速度
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject endText;
    
    private Rigidbody m_Rb;
    private int m_Count;
    private float m_MovementX;
    private float m_MovementY;
    
    // 当游戏开始时
    private void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Count = 0;
        
        SetCountText();
        endText.SetActive(false);
    }

    // 当玩家移动时
    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();

        m_MovementX = movementVector.x;
        m_MovementY = movementVector.y;
    }
    
    private void SetCountText()
    {
        countText.text = "Count: " + m_Count.ToString();
        if ( m_Count >= 9 )
        {
            endText.SetActive(true);
        }
    }

    // 在每帧渲染前
    private void FixedUpdate()
    {
        var movement = new Vector3(m_MovementX, 0.0f, m_MovementY);
        m_Rb.AddForce(movement * speed);
    }
    
    // 碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickUp")) return;
        other.gameObject.SetActive(false);
        m_Count += 1;
        
        SetCountText();
    }
}