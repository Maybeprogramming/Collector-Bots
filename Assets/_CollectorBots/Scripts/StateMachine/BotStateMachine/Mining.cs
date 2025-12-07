using UnityEngine;

public class Mining : IState
{
    private readonly BotStateMachine _stateMachine;

    public Mining(BotStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        if (_stateMachine.Bot.CurrentResource != null && _stateMachine.ResourceContainer.IsFull == false)
        {
            _stateMachine.ResourceContainer.Add(_stateMachine.Bot.CurrentResource);
        }

        Debug.Log($"Бот вошёл в состояние: {nameof(Mining)}");
    }

    public void Exit()
    {
        Debug.Log($"Бот вышел из состояния: {nameof(Mining)}");
    }

    public void Update()
    {
        if (_stateMachine.ResourceContainer.IsFull)
        {
            _stateMachine.TransiteTo<Walk>();
        }
    }
}