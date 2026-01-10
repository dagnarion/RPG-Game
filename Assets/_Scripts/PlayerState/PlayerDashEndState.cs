using UnityEngine;

public class PlayerDashEndState : PlayerState
{
    public PlayerDashEndState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        movement.SetVelocity(rigi.linearVelocityX*0.25f,rigi.linearVelocityY);
    }

    public override void Update()
    {
        if (IsAnimationDone)
        {
            state.ChangeState(player.GroundedState);
            return;
        }

        if (input.Player.Attack.WasPressedThisFrame())
        {
            state.ChangeState(player.AttackState);
            return;
        }
    }

}
