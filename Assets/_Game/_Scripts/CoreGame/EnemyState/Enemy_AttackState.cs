using UnityEngine;

public class Enemy_AttackState : EnemyState
{
    public Enemy_AttackState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _movement.SetVelocity(0,_movement.rigi.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();
        if (IsAnimationDone)
        {
            _stateMachine.ChangeState(_controller.BattleState);
            return;
        }
    }
}
