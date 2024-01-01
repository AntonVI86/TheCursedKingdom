using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollision : MonoBehaviour
{
    private HeroSpawner _spawner;
    private HeroStats _stats;

    private void Awake()
    {
        _spawner = GetComponentInParent<HeroSpawner>();
        _stats = GetComponent<HeroStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Item item))
        {
            if(_spawner.GetInventory().AddItem(item.ItemSO, item.Amount))
            {
                Destroy(item.gameObject);
            }
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _stats.TakeDamage(1);
        }
    }
}
