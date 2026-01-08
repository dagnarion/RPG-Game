using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : EntityState
{
    [SerializeField] protected PlayerController player;
    protected Animator animator;
    protected Rigidbody2D rigi;
    protected PlayerMovement movement;
    protected Player_InputTesst input;
    protected PlayerState(PlayerController _player,StateMachine _state, string _animationName) : base(_state, _animationName)
    {
        player = _player;
        animator = player.animator;
        rigi = player.Movement.rigi;
        movement = _player.Movement;
        input = player.input;
    }

    public override void Enter()
    {
        animator.SetBool(animationName,true);
    }
    public override void Exit()
    {
        animator.SetBool(animationName,false);
    }
}
