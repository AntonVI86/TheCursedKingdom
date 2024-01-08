using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroAttacker : HeroAnimator
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;

    private HeroStats _stats;

    private bool _isCanAttack = true;

    private void Awake()
    {
        _stats = GetComponent<HeroStats>();
        HeroAnimation = GetComponent<Animator>();
    }

    public void Attack()
    {
        float delay = 0.3f;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        else if (_isCanAttack)
        {
            SoundPlayer.Instance.PlayAttackSound();
            HeroAnimation.SetTrigger(AttackState);
            Invoke(nameof(KickEnemies), delay);

            _isCanAttack = false;

            StartCoroutine(AttackTimer());
        }
    }

    public void SetSide(float horizontal)
    {
        if (horizontal > 0)
        {
            _attackPoint.position = new Vector2(transform.position.x + 0.3f, _attackPoint.position.y);
        }
        if (horizontal < 0)
        {
            _attackPoint.position = new Vector2(transform.position.x - 0.3f, _attackPoint.position.y);
        }
    }

    private void KickEnemies()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(_attackPoint.position, _stats.Radius, _enemyLayer);

        foreach (var enemy in coll)
        {
            if (enemy.TryGetComponent(out EnemyHealth monster))
            {                
                monster.TakeDamage(_stats.SetDamage());
            }
        }
    }

    private IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(_stats.TimeToNewAttack);

        _isCanAttack = true;
    }
}
