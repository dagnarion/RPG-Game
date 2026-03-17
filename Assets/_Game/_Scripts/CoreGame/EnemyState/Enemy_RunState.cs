using UnityEngine;

public class Enemy_RunState : EnemyState
{
    private float timer;
    public Enemy_RunState(Enemy controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (!_movement.IsOnGround || _movement.IsOnWall)
        {
            timer = Time.time + _controller.AnimationTransitionTime;
            _movement.FlipHandler.HandleFlip(-_movement.FlipHandler.FacingDirection);
        }
    }

    public override void Update()
    {
        base.Update();
        
        if (_movement.IsOnWall)
        {
            timer = Time.time + _controller.AnimationTransitionTime;
        }
        
        if (_controller.Detecting.IsTargetOnChaseDetection() && Time.time > timer)
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
