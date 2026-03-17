using UnityEngine;

public class Enemy_StunnedState : EnemyState
{
    public Enemy_StunnedState(Enemy controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _controller.HandleStunn(false);
        _controller.vfxManager.StopAllVFX();
        _controller.vfxManager.GetVFX(TypeOfVFX.STUN).ApplyEffect();
        stateTimer = _movement.StunnTime;
        _movement.SetVelocity(_movement.StunnedVelocity.x * -_movement.FlipHandler.FacingDirection,_movement.StunnedVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        _controller.vfxManager.GetVFX(TypeOfVFX.STUN).ApplyEffect();
        if (stateTimer <= 0f)
        {
            state.ChangeState(_controller.BattleState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        _controller.vfxManager.GetVFX(TypeOfVFX.STUN).RemoveEffect();
    }
}
