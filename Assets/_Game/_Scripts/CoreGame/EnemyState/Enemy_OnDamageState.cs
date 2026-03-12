using UnityEngine;

public class Enemy_OnDamageState : EnemyState
{
    public Enemy_OnDamageState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (!_controller.IsAttacked)
        {
            state.ChangeState(_controller.BattleState);
            return;
        }
    }
}
