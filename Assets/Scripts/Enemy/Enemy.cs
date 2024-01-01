using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private GameObject _deathParticles;

    private HeroStats _hero;

    public void PlayParticle()
    {
        GameObject newParticles = Instantiate(_deathParticles, transform);
        newParticles.transform.SetParent(null);
    }

    public void GetPlayer(HeroStats hero)
    {
        _hero = hero;
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 point = new Vector3(0, -0.3f, 0);

        var offset = transform.position - _hero.transform.position + point;

        offset.Normalize();

        return offset;
    }

    public void CreateReward()
    {
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, _items.Count);
            var item = Instantiate(_items[index], transform);
            item.transform.SetParent(null);
            item.Drop();
        }
    }
}
