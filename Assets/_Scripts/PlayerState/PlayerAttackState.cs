using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float attackTimer;
    private float TimeCountDown;
    private int currentIndex = 0;
    private int IndexLimit = 3;
    public PlayerAttackState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        HandleIndex();
        ApplyAttackVelocity();
    }

    public override void Update()
    {
        base.Update();
        HandleAttack();
        if (IsAnimationDone)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        TimeCountDown = Time.time;
    }

    private void ApplyAttackVelocity()
    {
        attackTimer = movement.AttackDuration;
        movement.SetVelocity(movement.AttackVelocity[currentIndex-1].x * movement.IsFacingWall,movement.AttackVelocity[currentIndex-1].y);
    }

    private void HandleIndex()
    {
        currentIndex++;
        if (currentIndex > IndexLimit || Time.time > TimeCountDown + movement.AttackTimeReset) currentIndex = 1;
        animator.SetInteger("BaseAttackIndex",currentIndex);
    }

    private void HandleAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            movement.SetVelocity(0,rigi.linearVelocityY);
            return;
        }
    }
    
}
