using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        movement.SetVelocity(rigi.linearVelocityX, movement.JumpForce);
    }

    public override void Update()
    {
        animator.SetFloat("yVelocity",rigi.linearVelocityY);
        if(player.MovementInput.x != 0) movement.SetVelocity(movement.Speed * player.MovementInput.x * movement.InAirMoveMultiplier, rigi.linearVelocityY);
        if (rigi.linearVelocityY < 0)
        {
            state.ChangeState(player.FallState);
            return;
        }
    }

}
