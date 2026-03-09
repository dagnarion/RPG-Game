using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Update()
    {
        movement.Flip.HandleFlip(player.MovementInput.x);
        HandleWallSlide();
        if (input.Player.Jump.WasPressedThisFrame())
        {
            state.ChangeState(player.WallJumpState);
            return;
        }
        
        if(movement.IsOnGround)
        {
            state.ChangeState(player.GroundedState);
          if(player.MovementInput.x != movement.Flip.FacingDirection)  movement.Flip.HandleFlip(-movement.Flip.FacingDirection);
            return;
        }
        if(!movement.IsOnWall)
        {
          state.ChangeState(player.FallState);
          return;   
        }
    }

    private void HandleWallSlide()
    {
        if(player.MovementInput.y < 0)
        {
            movement.SetVelocity(rigi.linearVelocityX,rigi.linearVelocityY);
            return;    
        }
        movement.SetVelocity(rigi.linearVelocityX,rigi.linearVelocityY * movement.InWallSlideMultiplier);
        return;
    }
}
