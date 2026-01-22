

public abstract class EntityState
{
    protected StateMachine state;
    protected string animationName;
    public EntityState (StateMachine _state,string _animationName)
    {
        state = _state;
        animationName = _animationName;
    }
    public virtual void Enter()
    {
    }
    public virtual void Update()
    {
    }
    public virtual void Exit()
    {
    }

}
