using UnityEngine;

public class PlayerFallState : PlayerState
{
    private float fallSpeed;
    public PlayerFallState(Player _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Update()
    {
        base.Update();
        movement.Flip.HandleFlip(player.MovementInput.x);
        animator.SetFloat("yVelocity",rigi.linearVelocityY);
        fallSpeed = Mathf.Clamp(rigi.linearVelocityY,movement.MaxFallSpeed,float.MaxValue);
        
        if(player.MovementInput.x != 0) movement.SetVelocity(movement.Speed * player.MovementInput.x * movement.InAirMoveMultiplier,fallSpeed);
        
        if (input.Player.Attack.WasPressedThisFrame())
        {
            state.ChangeState(player.JumpAttack);
            return;
        }
        if(movement.IsOnGround)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
        if(movement.IsOnWall)
        {
            state.ChangeState(player.WallSlideState);
            return;
        }
        
    }
    
}
