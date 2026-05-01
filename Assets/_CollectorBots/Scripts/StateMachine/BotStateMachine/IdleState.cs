using UnityEngine;

public class IdleState : IState
{
    private readonly BotStateMachine _stateMachine;

    public IdleState(BotStateMachine stateMachine) =>    
        _stateMachine = stateMachine;    

    public void Enter() =>    
        Debug.Log($"Бот вошёл в состояние: {nameof(IdleState)}");    

    public void Exit() =>    
        Debug.Log($"Бот вышел из состояния: {nameof(IdleState)}");    

    public void Update()
    {
        if(_stateMachine.Bot.CurrentResource != null)
        {
            _stateMachine.TransiteTo<WalkState>();
        }
    }
}