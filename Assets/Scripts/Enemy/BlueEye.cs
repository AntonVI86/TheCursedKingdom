using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEye : MonoBehaviour
{
    private Enemy _enemy;
    private Rigidbody2D _rigidbody;
    private Vector2 _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition((transform.position - (_enemy.GetPlayerPosition() * 0.5f * Time.fixedDeltaTime)));
        float rot_z = Mathf.Atan2(_enemy.GetPlayerPosition().y, _enemy.GetPlayerPosition().x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot_z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out HeroStats hero))
        {
            _target = new Vector2(Random.Range(transform.position.x + 10f, transform.position.x - 10), Random.Range(transform.position.y + 10f, transform.position.y - 10));
            StartCoroutine(ChangeTarget());
        }
    }

    private IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(5f);
    }
}
