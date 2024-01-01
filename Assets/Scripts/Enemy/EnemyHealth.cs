using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private AudioClip _deathSfx;
    [SerializeField] private AudioClip _damageSfx;

    public event UnityAction Died;

    private float _currentHealth;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        SoundPlayer.Instance.PlayOtherSound(_damageSfx);

        if (_currentHealth <= 0)
        {
            _enemy.CreateReward();
            SoundPlayer.Instance.PlayOtherSound(_deathSfx);
            _enemy.PlayParticle();
            gameObject.SetActive(false);
            Died?.Invoke();
        }
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
}
