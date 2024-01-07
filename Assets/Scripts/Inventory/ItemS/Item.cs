using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSO _itemSO;
    [SerializeField] private int _amount;

    private Rigidbody2D _rigidbody;

    public ItemSO ItemSO => _itemSO;
    public int Amount => _amount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetAmount(int value)
    {
        _amount = value;
    }

    public void Drop()
    {
        Vector2 dir = new Vector2(Random.Range(-5, 5), 1).normalized;
        _rigidbody.AddForce(Vector2.up + dir * 2f, ForceMode2D.Impulse);
    }
}
