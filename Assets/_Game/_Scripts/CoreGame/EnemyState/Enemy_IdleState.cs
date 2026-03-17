using UnityEngine;

public class Enemy_IdleState : EnemyState
{
    private float timer;
    public Enemy_IdleState(Enemy controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
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
        if (_movement.IsOnWall)
        {
            timer = Time.time + _controller.AnimationTransitionTime;
        }
        
        if (_controller.Detecting.IsTargetOnChaseDetection() && Time.time > timer)
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
