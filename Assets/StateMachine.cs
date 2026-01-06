
public class StateMachine
{
    public EntityState currentState {get; private set;}

    public void Initialize(EntityState _currentState)
    {
        currentState = _currentState;
    }
    public void ChangeState(EntityState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }

    public void UpdateActiveState()
    {
        currentState.Update();
    }
}
