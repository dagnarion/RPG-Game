using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        animator.enabled = false;
        _movement.SetVelocity(rigi.linearVelocity.x,_movement.deadVelocity.y);
        rigi.gravityScale = 10;
    }

    public override void Update()
    {
        
    }
}
