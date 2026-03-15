using UnityEngine;

public class Enemy_StunnedState : EnemyState
{
    public Enemy_StunnedState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _controller.HandleStunn(false);
        stateTimer = _movement.StunnTime;
        _movement.SetVelocity(_movement.StunnedVelocity.x * -_movement.FlipHandler.FacingDirection,_movement.StunnedVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0f)
        {
            state.ChangeState(_controller.BattleState);
            return;
        }
        
    }
}
