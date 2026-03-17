using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(Enemy controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        animator.enabled = false;
        _controller.vfxManager.StopAllVFX();
    }

    public override void Update()
    {
        
    }
}
