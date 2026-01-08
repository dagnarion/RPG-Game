using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Update()
    {
        animator.SetFloat("yVelocity",rigi.linearVelocityY);
        if(player.MovementInput.x != 0) movement.SetVelocity(movement.Speed * player.MovementInput.x * movement.InAirMoveMultiplier, rigi.linearVelocityY);
        if(movement.IsOnGround)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
        
    }
    
}
