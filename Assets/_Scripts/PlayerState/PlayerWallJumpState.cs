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
        movement.SetVelocity(movement.WallJumpForce.x * -movement.IsFacingWall,movement.WallJumpForce.y);
        movement.HandleFlip(-movement.IsFacingWall);
        timeCount.ResetCountdown();
    }

    public override void Update()
    {
        base.Update();
        movement.HandleFlip(player.MovementInput.x);
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
