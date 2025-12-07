public interface IStateMachine
{
    void TransiteTo<T>() where T : IState;
    T GetCurrentState<T>() where T : IState;
}