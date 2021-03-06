using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManage : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int _puntaje = 50;
    [SerializeField] private int health = 0;

    private Rigidbody2D _enemyRb;
    private int _turn;
    private Vector2 _direction = Vector2.down;
    private Vector2 _position;

    private IDictionary<int, Vector2> _directions = new Dictionary<int, Vector2>(){
        {0, Vector2.right},
        {1, Vector2.up},
        {2, Vector2.left},
        {3, Vector2.down}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _enemyRb.velocity = speed*Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Health_system bomberman = col.transform.GetComponent<Health_system>();
        if(bomberman!=null)
        {
            bomberman.TakeDamage();
        }
        else
        {
            _position = transform.position;
            _position.x = Mathf.Round(_position.x);
            _position.y = Mathf.Round(_position.y);
            transform.position = _position;

            _turn = Random.Range(0, 4);
            _enemyRb.velocity = speed * _directions[_turn];
        }
    }

    public void TakeDamage()
   {
       health--;
       if (health < 0)
       {
           gameObject.SetActive(false); 
           if (Events.OnEnemyDeathEvent != null)
           {
               Events.OnEnemyDeathEvent(_puntaje);
           }
       }
   }
    

    
}
