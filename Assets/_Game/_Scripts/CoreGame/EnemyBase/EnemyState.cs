using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy _controller;
    protected StateMachine _stateMachine;
    protected EnemyMovement _movement;
    public EnemyState(Enemy controller,EnemyMovement movement,StateMachine _state, string _animationName) : base(_state, _animationName)
    {
        _controller = controller;
        animator = _controller.animator;
        _movement = movement;
        _stateMachine = controller.StateMachine;
        rigi = _movement.rigi;
    }

    public override void Enter()
    {
        base.Enter();
        float battleAnimSpeedMultiphyler = _movement.ChaseSpeed / _movement.MoveSpeed;
        animator.SetFloat("AnimationSpeedMultiphyler", _movement.AnimationSpeedMultiphyler);
        animator.SetFloat("BattleSpeedMultiphyler", battleAnimSpeedMultiphyler);
    }

    public override void Update()
    {
        base.Update();
        if (_controller.IsAttacked)
        {
            state.ChangeState(_controller.OnDamageState);
            return;
        }
    }
}
