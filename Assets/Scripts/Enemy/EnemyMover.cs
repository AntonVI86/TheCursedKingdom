using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float upPoint = 0.5f;
    [SerializeField] private float radius = 0.2f;

    private Rigidbody2D _rigidbody;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(_enemy.GetPlayerPosition().x > transform.position.x)
       _rigidbody.MovePosition(Vector2.right * _speed * Time.fixedDeltaTime);
    }
}
