using UnityEngine;

public class PlayerCounterState : PlayerState
{
    private bool counterSomebody;
    public PlayerCounterState(Player _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanDoCounter = false;
       if(rigi.linearVelocityY > 0) movement.SetVelocity(0,0);
        stateTimer = 0.2f;
        counterSomebody = false;
    }

    public override void Update()
    {
        base.Update();
        movement.SetVelocity(0,movement.rigi.linearVelocityY);

        if (player.CanCounter())
        {
            counterSomebody = true;
            animator.SetBool("PerformCounter",true);
        }

        if (IsAnimationDone)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
        
        if (stateTimer <= 0f && !counterSomebody)
        {
            state.ChangeState(player.GroundedState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        animator.SetBool("PerformCounter",false);
    }
}
