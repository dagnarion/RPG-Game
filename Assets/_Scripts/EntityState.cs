

public abstract class EntityState
{
    protected StateMachine state;
    protected string animationName;
    public EntityState (StateMachine _state,string _animationName)
    {
        state = _state;
        animationName = _animationName;
    }
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
