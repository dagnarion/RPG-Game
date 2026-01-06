using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        animator.SetBool(animationName, true);
    }

    public override void Update()
    {
        if(player.MovementInput.x == 0)
        {
            state.ChangeState(player.IdleState);
            return;
        }
        player.Movement.SetVelocity(player.Movement.speed * player.MovementInput.x, rigi.linearVelocity.y);
        player.Movement.HandleFlip(player.MovementInput.x);
    }

    public override void Exit()
    {
        animator.SetBool(animationName, false);
    }
}
