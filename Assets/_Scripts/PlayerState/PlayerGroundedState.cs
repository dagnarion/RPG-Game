using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        movement.SetVelocity(0,rigi.linearVelocityY);
    }


    public override void Update()
    {
        animator.SetFloat("xVelocity",rigi.linearVelocity.x);
        movement.SetVelocity(movement.Speed * player.MovementInput.x,rigi.linearVelocityY);
        if(rigi.linearVelocityY < 0)
        {
            state.ChangeState(player.FallState);
            return;
        }
        if(input.Player.Jump.WasPressedThisFrame())
        {
            state.ChangeState(player.JumpState);
            return;
        }
    }

}
