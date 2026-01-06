using UnityEngine;

public abstract class PlayerState : EntityState
{
    [SerializeField] protected PlayerController player;
    protected Animator animator;
    protected Rigidbody2D rigi;
    protected PlayerState(PlayerController _player,StateMachine _state, string _animationName) : base(_state, _animationName)
    {
        player = _player;
        animator = player.animator;
        rigi = player.Movement.rigi;
    }
}
