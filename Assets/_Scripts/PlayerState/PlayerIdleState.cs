using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        animator.SetBool(animationName, true);
    }

    public override void Update()
    {
        // if (player.MovementInput.x != 0)
        // {
        //     state.ChangeState(player.RunState);
        //     return;
        // }
        player.Movement.SetVelocity(0,rigi.linearVelocity.y);
    }

    public override void Exit()
    {
        animator.SetBool(animationName, false);
    }

}
