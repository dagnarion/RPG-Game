using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float attackTimer;
    private float TimeCountDown;
    private int currentIndex = 0;
    private int IndexLimit = 3;
    private bool comboAttackQueue = false;
    public PlayerAttackState(PlayerController _player, StateMachine _state, string _animationName) : base(_player, _state, _animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        comboAttackQueue = false;
        HandleIndex();
        ApplyAttackVelocity();
    }

    public override void Update()
    {
        base.Update();
        HandleAttack();
        
        if (input.Player.Attack.WasPressedThisFrame())
        {
            if(currentIndex < IndexLimit ) comboAttackQueue = true;
        }
        
        if (IsAnimationDone)
        {
            if (comboAttackQueue == true)
            {
                animator.SetBool(animationName,false);
                player.AttackController.EnterAttackWithoutDelay(state,player.AttackState);
            }
            else state.ChangeState(player.GroundedState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        TimeCountDown = Time.time;
    }

    private void ApplyAttackVelocity()
    {
        attackTimer = player.AttackController.AttackDuration;
        movement.Flip.HandleFlip(player.MovementInput.x);
        movement.SetVelocity(player.AttackController.AttackVelocity[currentIndex-1].x * movement.Flip.FacingDirection,player.AttackController.AttackVelocity[currentIndex-1].y);
    }

    private void HandleIndex()
    {
        currentIndex++;
        if (currentIndex > IndexLimit || Time.time > TimeCountDown + player.AttackController.AttackTimeReset)
        {
            currentIndex = 1;
        }
        animator.SetInteger("BaseAttackIndex",currentIndex);
    }

    private void HandleAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
         if(!player.IsAttacked) movement.SetVelocity(0,rigi.linearVelocityY);
            return;
        }
    }
    
}
