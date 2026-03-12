using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;
    
    public Enemy_BattleState(EnemyController controller, EnemyMovement movement, StateMachine _state, string _animationName) : base(controller, movement, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(_controller!=null) player = _controller.sendered;
        if (_controller.Detecting.IsTargetOnChaseDetection())
            player = _controller.Detecting.IsTargetOnChaseDetection().transform;
       if(_movement.FlipHandler.FacingDirection != DirectionToPlayer())  _movement.FlipHandler.HandleFlip(-_movement.FlipHandler.FacingDirection);
    }

    public override void Update()
    {
        base.Update();
        if (!_controller.Detecting.IsTargetOnChaseDetection() || _controller.movement.IsOnWall)
        { 
            _stateMachine.ChangeState(_controller.RunState);
            return;
        }
         animator.SetFloat("xVelocity",_movement.rigi.linearVelocityX);
        if(_movement.FlipHandler.FacingDirection != DirectionToPlayer())  _movement.FlipHandler.HandleFlip(-_movement.FlipHandler.FacingDirection);
        _movement.SetVelocity(_movement.ChaseSpeed * DirectionToPlayer(),_movement.rigi.linearVelocityY);

        if (_controller.Detecting.CanRetreat())
        {
            _movement.SetVelocity(_movement.RetreatVelocity.x * -DirectionToPlayer(),_movement.RetreatVelocity.y);
        }
        
        if (_controller.Detecting.CanAttack() && !_controller.Detecting.CanRetreat())
        {
            _stateMachine.ChangeState(_controller.AttackState);
            return;
        }
        
    }
    
    private int DirectionToPlayer()
    {
        if (player == null) return 0;
        return player.position.x > _controller.transform.position.x ? 1 : -1;
    }
    
    
    
    
    
}
