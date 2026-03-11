using UnityEngine;

public class EnemyState : EntityState
{
    protected EnemyController _controller;
    protected StateMachine _stateMachine;
    protected EnemyMovement _movement;
    protected float stateTimer;
    public EnemyState(EnemyController controller,EnemyMovement movement,StateMachine _state, string _animationName) : base(_state, _animationName)
    {
        _controller = controller;
        animator = _controller.animator;
        _movement = movement;
        _stateMachine = controller.StateMachine;
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
        stateTimer -= Time.deltaTime;
        if (_controller.IsAttacked)
        {
            state.ChangeState(_controller.OnDamageState);
            return;
        }
    }
}
