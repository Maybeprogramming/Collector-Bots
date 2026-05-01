using UnityEngine;

public class WalkState : IState
{
    private readonly BotStateMachine _stateMachine;
    private Vector3 _target;
    private IMover _mover;

    public WalkState(BotStateMachine stateMachine) =>    
        _stateMachine = stateMachine;
    
    public void Enter()
    {
        _mover = _stateMachine.GetBotMover;

        if (_stateMachine.Bot.CurrentResource != null && _stateMachine.Inventory.IsFull == false)
        {
            _target = _stateMachine.Bot.CurrentResource.transform.position;
        }
        else if (_stateMachine.Inventory.IsFull) 
        {
            _target = _stateMachine.Bot.CurrentBasePosition;
        }

        _mover.MoveTo(_target);

        Debug.Log($"Бот вошёл в состояние: {nameof(WalkState)}");
    }

    public void Exit()
    {
        _mover.Stop();
        Debug.Log($"Бот вышел из состояния: {nameof(WalkState)}");
    }

    public void Update()
    {
        if (_mover.IsCompliteMoving() && _stateMachine.Inventory.IsFull == false)
        {
            _stateMachine.TransiteTo<MiningState>();
        }
        else if (_mover.IsCompliteMoving() && _stateMachine.Inventory.IsFull)
        {
            _stateMachine.TransiteTo<DropState>();
        }
    }
}