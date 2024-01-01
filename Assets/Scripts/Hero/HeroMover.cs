using UnityEngine;

public class HeroMover : HeroAnimator
{   
    [SerializeField] private float _speed = 2f;

    private HeroAttacker _attacker;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        HeroAnimation = GetComponent<Animator>();
        _attacker = GetComponent<HeroAttacker>();
    }

    public void Move(float horizontal)
    {
        Vector2 direction = new Vector2(horizontal * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
        
        _rigidbody.velocity = direction;

        Flip(horizontal);
        MoveAnim(horizontal);
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0)
        {
            _renderer.flipX = false;
        }
        if(horizontal < 0)
        {
            _renderer.flipX = true;
        }

        _attacker.SetSide(horizontal);
    }
}
