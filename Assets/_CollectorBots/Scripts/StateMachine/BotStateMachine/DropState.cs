using UnityEngine;

public class DropState : IState
{
    private readonly BotStateMachine _stateMachine;

    public DropState(BotStateMachine stateMachine) =>    
        _stateMachine = stateMachine;

    public void Enter()
    {
        _stateMachine.Bot.GiveResource(_stateMachine.Inventory.Drop(_stateMachine.Bot.CurrentBasePosition));

        Debug.Log($"Бот вошёл в состояние: {nameof(DropState)}");
    }

    public void Exit() =>    
        Debug.Log($"Бот вышел из состояния: {nameof(DropState)}");    

    public void Update()
    {
        if (_stateMachine.Inventory.IsFull == false)
        { 
            _stateMachine.Bot.SetResourceToMine(null);
            _stateMachine.TransiteTo<IdleState>();
        }
    }
}