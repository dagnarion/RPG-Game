using UnityEngine;

public class PlayerDashState : PlayerState
{
    private CustomTimeCount timeCount;
    private float originGravityScale;
    public PlayerDashState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
        timeCount = new CustomTimeCount();
        timeCount.SetDuration(movement.DashDuration);
    }

    public override void Enter()
    {
        base.Enter();
        animator.SetFloat("DashValue",0);
        originGravityScale = rigi.gravityScale;
        rigi.gravityScale = 0;
        timeCount.ResetCountdown();
    }

    public override void Update()
    {
        movement.SetVelocity(movement.DashForce * movement.Speed * movement.IsFacingWall,0);
        if (movement.IsOnWall)
        {   
            if(!movement.IsOnGround)  state.ChangeState(player.WallSlideState);
            else 
            state.ChangeState(player.GroundedState);
            return;
        } 

        if (timeCount.IsComplete())
        {
            if(movement.IsOnGround) 
                state.ChangeState(player.DashEndState);
            else 
                state.ChangeState(player.FallState);
            return;
        }
    }

    public override void Exit()
    {
        animator.SetFloat("DashValue",1);
        rigi.gravityScale = originGravityScale;
        base.Exit();
    }
    
    
}
