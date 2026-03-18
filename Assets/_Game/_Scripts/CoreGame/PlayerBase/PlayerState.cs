using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : EntityState
{
    [SerializeField] protected Player player;
    protected PlayerMovement movement;
    protected Player_InputTesst input;
    protected bool CanDoCounter = true;
    protected PlayerState(Player _player,StateMachine _state, string _animationName) : base(_state, _animationName)
    {
        player = _player;
        animator = player.animator;
        rigi = player.Movement.rigi;
        movement = _player.Movement;
        input = player.input;
    }
    
    public override void Update()
    {
        base.Update();
        if (player.IsAttacked)
        {
            state.ChangeState(player.OnDamageState);
            return;
        }
        
        if (CanDash() && input.Player.Dash.WasPressedThisFrame())
        {
            state.ChangeState(player.DashState);
            return;
        }

        if (input.Player.Counter.WasPressedThisFrame() && CanDoCounter)
        {
            state.ChangeState(player.CounterState);
        }
    }
    
    private bool CanDash()
    {
        if (movement.IsOnWall) return false;
        if(this.GetType() == typeof(PlayerDashState)) return false;
        return true;
    }
}
