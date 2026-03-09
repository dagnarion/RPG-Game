using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    private CustomTimeCount timeCount;
    public PlayerWallJumpState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
        timeCount = new CustomTimeCount();
        timeCount.SetDuration(0.2f);
    }

    public override void Enter()
    {
        base.Enter();
        movement.SetVelocity(movement.WallJumpForce.x * -movement.Flip.FacingDirection,movement.WallJumpForce.y);
        movement.Flip.HandleFlip(-movement.Flip.FacingDirection);
        timeCount.ResetCountdown();
    }

    public override void Update()
    {
        base.Update();
        movement.Flip.HandleFlip(player.MovementInput.x);
        if (input.Player.Attack.WasPressedThisFrame())
        {
            state.ChangeState(player.JumpAttack);
            return;
        }

        if (movement.IsOnGround)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
        
        
        if ( (rigi.linearVelocityY < 0 || player.MovementInput.x != 0) && timeCount.IsComplete() )
        {
            state.ChangeState(player.FallState);
            return;
        }

        if (movement.IsOnWall && timeCount.IsComplete())
        {
            state.ChangeState(player.WallSlideState);
            return;
        }
    }
}
