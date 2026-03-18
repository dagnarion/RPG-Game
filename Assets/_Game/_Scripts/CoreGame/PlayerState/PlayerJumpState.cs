using System;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private float Timer;
    public PlayerJumpState(Player _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        movement.SetVelocity(rigi.linearVelocityX, movement.JumpForce);
    }

    public override void Update()
    {
        base.Update();
        movement.Flip.HandleFlip(player.MovementInput.x);
        animator.SetFloat("yVelocity",rigi.linearVelocityY);
        
        if (input.Player.Attack.WasPressedThisFrame())
        {
            state.ChangeState(player.JumpAttack);
            return;
        }
        
        if(player.MovementInput.x != 0) movement.SetVelocity(movement.Speed * player.MovementInput.x * movement.InAirMoveMultiplier, rigi.linearVelocityY);
        
        
        if (rigi.linearVelocityY < 0 || !input.Player.Jump.IsPressed())
        {
            movement.SetVelocity(rigi.linearVelocityX,rigi.linearVelocityY * 0.5f);
            state.ChangeState(player.FallState);
            return;
        }
    }

}
