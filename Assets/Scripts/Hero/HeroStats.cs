using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroStats : MonoBehaviour
{
    [SerializeField] private int _jumpCount = 1;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private int _maxHealth;

    public static HeroStats Instance;

    private int _currentHealth;

    public event UnityAction<int> HealthValueChanged;
    public event UnityAction Died;

    private float _timeToNewAttack = 1f;

    public int JumpCount => _jumpCount;
    public float Damage => _damage;
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
}
