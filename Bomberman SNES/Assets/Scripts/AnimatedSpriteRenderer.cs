using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRender : MonoBehaviour
{
   
   private SpriteRenderer _spriteRenderer;
   public Sprite idleSprite;
   public Sprite[] animationSprites;
   public float animationTime = 0.25f;
   private int animationFrame;

   public bool loop = true;
   public bool idle = true;
   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void OnEnable()
   {
      _spriteRenderer.enabled = true;
   }

   private void OnDisable()
   {
      _spriteRenderer.enabled = false; 
   }

   private void Start()
   {
      InvokeRepeating(nameof(NextFrame),animationTime,animationTime);
   }

   private void NextFrame()
   {
      animationFrame++;
      
      if (loop && animationFrame >= animationSprites.Length)
      {
         animationFrame = 0;
      }

      if (idle)
      {
         _spriteRenderer.sprite = idleSprite;
      }
      else if (animationFrame>=0 && animationFrame<animationSprites.Length)
      {
         _spriteRenderer.sprite = animationSprites[animationFrame];
      }
   }
}
