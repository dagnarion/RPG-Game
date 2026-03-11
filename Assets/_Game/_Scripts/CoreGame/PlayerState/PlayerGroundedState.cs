using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    private float Timer = 0;
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
        base.Update();
        
        movement.Flip.HandleFlip(player.MovementInput.x);
        if(!movement.IsOnWall) animator.SetFloat("xVelocity",player.MovementInput.x);
        else animator.SetFloat("xVelocity",0);
        if(!player.IsAttacked) movement.SetVelocity(movement.Speed * player.MovementInput.x,rigi.linearVelocityY);
        
        if (rigi.linearVelocityY < 0 && !movement.IsOnGround)
        {
            Timer -= Time.deltaTime;
        }
        else Timer = movement.CoyoteTime;
        
        if (Timer < 0)
        {
            state.ChangeState(player.FallState);
            return;
        }
        
        if(input.Player.Jump.WasPressedThisFrame())
        {
            state.ChangeState(player.JumpState);
            return;
        }

        if (input.Player.Attack.WasPressedThisFrame())
        { 
            movement.SetVelocity(0,rigi.linearVelocityY);
           state.ChangeState(player.AttackState);
        }
    }
}
