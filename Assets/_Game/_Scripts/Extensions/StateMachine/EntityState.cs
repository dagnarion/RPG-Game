using UnityEngine;

public abstract class EntityState
{
    // Reference
    protected StateMachine state;
    protected Animator animator;
    protected Rigidbody2D rigi;
    // Value
    protected string animationName;
    protected bool IsAnimationDone;
    public EntityState (StateMachine _state,string _animationName)
    {
        state = _state;
        animationName = _animationName;
    }
    
    public virtual void Enter()
    {
        animator.SetBool(animationName,true);
        IsAnimationDone = false;
    }
    
    public virtual void Update()
    {
    }
    
    public virtual void Exit()
    {
        animator.SetBool(animationName,false);
    }
    
    public void CompleteAnimation() => IsAnimationDone = true;

}
