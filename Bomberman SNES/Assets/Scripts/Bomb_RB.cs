using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_RB : MonoBehaviour
{
    [SerializeField] public float speed = 3;

    [SerializeField] private Rigidbody2D _rb;
    // Start is called before the first frame update
    
    private Vector2 _dir;
    
    void Start()
    {
        Init();
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _dir= new Vector2 (x: horizontal,y: vertical);
        _dir.Normalize();
        _dir = _dir * speed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _dir;  
    }
}
