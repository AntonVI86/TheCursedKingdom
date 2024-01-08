using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroStats : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private int _strength;
    [SerializeField] private int _agility;
    [SerializeField] private int _vitality;
    [SerializeField] private int _armor;
    [SerializeField] private int _maxHealth;

    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private float _minDamage = 1;
    [SerializeField] private float _maxDamage = 3;

    [SerializeField] private int _jumpCount = 1;

    public static HeroStats Instance;

    private float _damage;
    private int _currentHealth;
    private float _timeToNewAttack = 1f;

    public event UnityAction<int> HealthValueChanged;
    public event UnityAction Died;

    public int Level => _level;
    public int Strength => _strength;
    public int Agility => _agility;
    public int Vitality => _vitality;
    public int Armor => _armor;
    public int JumpCount => _jumpCount;
    public float MinDamage => _minDamage;
    public float MaxDamage => _maxDamage;
    public float Radius => _radius;
    public float TimeToNewAttack => _timeToNewAttack;
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        Instance = null;

        if (Instance == null)
        {
            Instance = this;
        }

        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        HealthValueChanged?.Invoke(CurrentHealth);

        if(_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    public bool Heal(int value)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth += value;

            HealthValueChanged?.Invoke(CurrentHealth);

            return true;
        }

        return false;
    }

    public float SetDamage()
    {
        _damage = Random.Range(_minDamage, _maxDamage);
        return _damage;
    }

    public void SumStats(int koef,int armor, float minDamage, float maxDamage, int strength, int agility, int vitality, int maxHealth, float attackSpeed)
    {
        _armor += armor * koef;
        _minDamage += minDamage * koef;
        _maxDamage += maxDamage * koef;
        _strength += strength * koef;
        _agility += agility * koef;
        _vitality += vitality * koef;
        _maxHealth += maxHealth * koef;
        _timeToNewAttack += attackSpeed * koef;

        StatsView.Instance.UpdateViewStats();
    }
}
