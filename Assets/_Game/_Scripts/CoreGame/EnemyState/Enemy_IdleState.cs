using TMPro.EditorUtilities;
using UnityEngine;

public class Enemy_IdleState : EnemyState
{
    public Enemy_IdleState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = _movement.IdleTime;
    }

    public override void Update()
    {
        base.Update();
        if (_controller.Detecting.IsTargetOnChaseDetection() != null && !_movement.IsOnWall)
        {
            _stateMachine.ChangeState(_controller.BattleState);
            return;
        }
        
        if (stateTimer <= 0f)
        {
            _stateMachine.ChangeState(_controller.RunState);
        }
    }
}
