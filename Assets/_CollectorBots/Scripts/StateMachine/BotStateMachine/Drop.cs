using UnityEngine;

public class Drop : IState
{
    private readonly BotStateMachine _stateMachine;

    public Drop(BotStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _stateMachine.Bot.GiveResource(_stateMachine.ResourceContainer.Drop(_stateMachine.Bot.CurrentBasePosition));

        Debug.Log($"Бот вошёл в состояние: {nameof(Drop)}");
    }

    public void Exit()
    {
        Debug.Log($"Бот вышел из состояния: {nameof(Drop)}");
    }

    public void Update()
    {
        if (_stateMachine.ResourceContainer.IsFull == false)
        { 
            _stateMachine.TransiteTo<Idle>();
            _stateMachine.Bot.SetResourceToMine(null);
        }
    }
}