using UnityEngine;

public class Enemy_RunState : EnemyState
{
    public Enemy_RunState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (!_movement.IsOnGround || _movement.IsOnWall)
        {
            _movement.FlipHandler.HandleFlip(-_movement.FlipHandler.FacingDirection);
        }
    }

    public override void Update()
    {
        base.Update();
        if (_controller.Detecting.IsTargetOnChaseDetection() != null && !_movement.IsOnWall)
        {
            _stateMachine.ChangeState(_controller.BattleState);
            return;
        }
        _movement.SetVelocity(_movement.MoveSpeed * _movement.FlipHandler.FacingDirection,_movement.rigi.linearVelocityY);
        if (!_movement.IsOnGround || _movement.IsOnWall)
        {
            _stateMachine.ChangeState(_controller.IdleState);
        }
    }
}
