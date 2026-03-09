using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    public Enemy_DeadState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        animator.SetTrigger(animationName);
    }
    
    
    
}
