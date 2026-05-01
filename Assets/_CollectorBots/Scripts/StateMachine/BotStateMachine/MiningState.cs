using UnityEngine;

public class MiningState : IState
{
    private readonly BotStateMachine _stateMachine;

    public MiningState(BotStateMachine stateMachine) =>    
        _stateMachine = stateMachine;    

    public void Enter()
    {
        if (_stateMachine.Bot.CurrentResource != null && _stateMachine.Inventory.IsFull == false)
        {
            _stateMachine.Inventory.Add(_stateMachine.Bot.CurrentResource);
        }

        Debug.Log($"Бот вошёл в состояние: {nameof(MiningState)}");
    }

    public void Exit() =>    
        Debug.Log($"Бот вышел из состояния: {nameof(MiningState)}");

    public void Update()
    {
        if (_stateMachine.Inventory.IsFull)
        {
            _stateMachine.TransiteTo<WalkState>();
        }
    }
}