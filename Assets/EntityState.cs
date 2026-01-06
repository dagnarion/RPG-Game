

public abstract class EntityState
{
    protected StateMachine state;
    protected string stateName;
    public EntityState (StateMachine _state,string _stateName)
    {
        state = _state;
        stateName = _stateName;
    }
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
