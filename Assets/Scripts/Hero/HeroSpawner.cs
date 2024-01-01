using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private Inventory _inventory;

    private HeroStats _stats;

    private void Awake()
    {
        var hero = Instantiate(_hero, transform);
        _stats = hero.GetComponent<HeroStats>();
    }

    public HeroStats GetHero()
    {
        return _stats;
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }
}
