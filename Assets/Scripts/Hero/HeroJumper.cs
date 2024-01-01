using System.Collections;
using UnityEngine;

public class HeroJumper : HeroAnimator
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded = true;

    private Rigidbody2D _rigidbody;
    private HeroStats _stats;
    private int _jumpCount;

    private void Awake()
    {
        _stats = GetComponent<HeroStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
        HeroAnimation = GetComponent<Animator>();
    }

    private void Start()
    {
        _jumpCount = _stats.JumpCount;
    }

    public void Jump()
    {
        IsGrounded();

        if(_isGrounded)
        {
            PerfomJump();
            _isGrounded = false;
        }
        else
        {
            if(_jumpCount > 0)
            {
                PerfomJump();
                _jumpCount--;
            }
        }
    }

    private void PerfomJump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        HeroAnimation.SetTrigger(JumpState);
        HeroAnimation.SetBool(FallState, true);

        SoundPlayer.Instance.PlayJumpSound();
    }

    private void IsGrounded()
    {
        Vector2 size = new Vector2(0.05f, 0.01f);

        Collider2D[] coll = Physics2D.OverlapBoxAll(_groundCheckPoint.position, size, 0, _layer);

        _isGrounded = coll.Length > 0;

        if (_isGrounded)
        {
            _jumpCount = _stats.JumpCount;
            HeroAnimation.SetBool(FallState, true);
            HeroAnimation.SetBool(FallState, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground ground))
        {
            HeroAnimation.SetBool(FallState, true);
            HeroAnimation.SetBool(FallState, false);
        }
    }
}
