using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
      public new Rigidbody2D _rb { get; private set;  }
      private Vector2 _dir = Vector2.down;
      public float speed = 10f; // POWER UP

      public KeyCode inputUp = KeyCode.UpArrow;
      public KeyCode inputDown = KeyCode.DownArrow;
      public KeyCode inputLeft = KeyCode.LeftArrow;
      public KeyCode inputRight = KeyCode.RightArrow;

      public AnimatedSprite spriteRendererUp;
      public AnimatedSprite spriteRendererDown;
      public AnimatedSprite spriteRendererLeft;
      public AnimatedSprite spriteRendererRight;
      private AnimatedSprite activateSpriteRenderer;

      private void Start()
      {
          // Load level
          DontDestroyOnLoad(gameObject);
      }

      private void Awake()
      {
          _rb = GetComponent<Rigidbody2D>();
          activateSpriteRenderer = spriteRendererDown;
          
      }
      
      private void Update()
      {
              if (Input.GetKey(inputUp))
              {
                  SetDirection(Vector2.up, spriteRendererUp);
              }
              else if (Input.GetKey(inputDown))
              {
                  SetDirection(Vector2.down,spriteRendererDown);
              }
              
              else if (Input.GetKey(inputLeft))
              {
                  SetDirection(Vector2.left,spriteRendererLeft);
              }
              
              else if (Input.GetKey(inputRight))
              {
                  SetDirection(Vector2.right,spriteRendererRight);
              }

              else
              {
                  SetDirection(Vector2.zero,activateSpriteRenderer);
              }
              
      }

      private void FixedUpdate()
      {
          Vector2 position = _rb.position;
          Vector2 translation = _dir * speed * Time.fixedDeltaTime; 
          
          _rb.MovePosition(position + translation);
      }

      private void SetDirection(Vector2 newDirection, AnimatedSprite spriteRenderer)

      {
          _dir = newDirection;

          spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
          spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
          spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
          spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

          activateSpriteRenderer = spriteRenderer;
          activateSpriteRenderer.idle = _dir == Vector2.zero;

      }

      private void OnLevelWasLoaded(int level)
      {
          FindStartPos();
      }

      void FindStartPos()
      {
          transform.position = GameObject.FindWithTag("StartPos").transform.position;
      }
}
