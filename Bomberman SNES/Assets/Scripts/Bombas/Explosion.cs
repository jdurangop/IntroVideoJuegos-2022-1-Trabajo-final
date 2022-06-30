using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // References for the different states of the explosion
    public AnimatedSprite start;
    public AnimatedSprite middle;
    public AnimatedSprite end;

    // Which of the states previously described the script is going to enable
    public void SetActiveRenderer(AnimatedSprite renderer)
    {
        start.enabled = renderer == start;
        middle.enabled = renderer == middle;
        end.enabled = renderer == end;
    }

    // This function rotates the available sprites of the explosion
    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
    
    // This function destroys the explosion game object after certain amount of time
    public void DestroyAfter(float seconds)
    {
        Destroy(gameObject, seconds); 
    }
}
