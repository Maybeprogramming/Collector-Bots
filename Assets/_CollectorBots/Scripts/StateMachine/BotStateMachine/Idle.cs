using UnityEngine;

public class Idle : IState
{
    private readonly BotStateMachine _stateMachine;

    public Idle(BotStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log($"Бот вошёл в состояние: {nameof(Idle)}");
    }

    public void Exit()
    {
        Debug.Log($"Бот вышел из состояния: {nameof(Idle)}");
    }

    public void Update()
    {
        if(_stateMachine.Bot.CurrentResource != null)
        {
            _stateMachine.TransiteTo<Walk>();
        }
    }
}