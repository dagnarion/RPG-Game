using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : EntityState
{
    [SerializeField] protected PlayerController player;
    protected Animator animator;
    protected Rigidbody2D rigi;
    protected PlayerMovement movement;
    protected Player_InputTesst input;
    protected bool IsAnimationDone;
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
        IsAnimationDone = false;
    }

    public override void Update()
    {
        if (CanDash() && input.Player.Dash.WasPressedThisFrame())
        {
            state.ChangeState(player.DashState);
            return;
        }
    }
    
    public override void Exit()
    {
        animator.SetBool(animationName,false);
    }

    public void CompleteAnimation() => IsAnimationDone = true;

    private bool CanDash()
    {
        if (movement.IsOnWall) return false;
        if(this.GetType() == typeof(PlayerDashState)) return false;
        return true;
    }
}
