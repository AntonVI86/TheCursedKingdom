using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    protected int MoveState = Animator.StringToHash("Move");
    protected int AttackState = Animator.StringToHash("Attack");
    protected int JumpState = Animator.StringToHash("Jump");
    protected int FallState = Animator.StringToHash("Fall");

    protected Animator HeroAnimation;

    protected void MoveAnim(float horizontal)
    {
        if(horizontal != 0)
        {
            HeroAnimation.SetBool(MoveState, true);
        }
        else
        {
            HeroAnimation.SetBool(MoveState, false);
        }
    }


}
