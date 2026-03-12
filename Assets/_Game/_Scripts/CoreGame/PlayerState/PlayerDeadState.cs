using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        
    }
}
