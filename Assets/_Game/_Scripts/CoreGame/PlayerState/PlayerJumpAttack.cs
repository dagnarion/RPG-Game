using UnityEngine;

public class PlayerJumpAttack : PlayerState
{
    private bool IsOnGround = false;
    public PlayerJumpAttack(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        IsOnGround = false;
        movement.SetVelocity(player.AttackController.JumpAttackVelocity.x * movement.Flip.FacingDirection,player.AttackController.JumpAttackVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (movement.IsOnGround && !IsOnGround)
        {
            IsOnGround = true;
            movement.SetVelocity(0,rigi.linearVelocityY);
            animator.SetTrigger("JumpAttackTrigger");
            return;
        }
        
        if (IsAnimationDone)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
    }
    
}
