using UnityEngine;

public class AnimationTriggerHandler : IComplete
{
    private StateMachine _stateMachine;

    public AnimationTriggerHandler(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void CompleteAnimation()
    {
        EntityState currentState = (EntityState)_stateMachine.currentState;
        currentState.CompleteAnimation();
    }
}
