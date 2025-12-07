public interface IStateMachine
{
    IState GetCurrentState {  get; }
    void TransiteTo<T>() where T : IState;
}