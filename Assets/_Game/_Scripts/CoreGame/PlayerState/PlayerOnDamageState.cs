using UnityEngine;

public class PlayerOnDamageState : PlayerState
{
    public PlayerOnDamageState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Update()
    {
        if (!player.IsAttacked)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
    }
}
