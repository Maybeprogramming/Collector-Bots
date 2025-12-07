using UnityEngine;

public class Walk : IState
{
    private readonly BotStateMachine _stateMachine;
    private Vector3 _target;

    private IMover _mover;

    public Walk(BotStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _mover = _stateMachine.GetBotMover();

        if (_stateMachine.Bot.CurrentResource != null && _stateMachine.ResourceContainer.IsFull == false)
        {
            _target = _stateMachine.Bot.CurrentResource.transform.position;
        }
        else if (_stateMachine.ResourceContainer.IsFull) 
        {
            _target = _stateMachine.Bot.CurrentBasePosition;
        }

        _mover.MoveTo(_target);

        Debug.Log($"Бот вошёл в состояние: {nameof(Walk)}");
    }

    public void Exit()
    {
        _mover.Stop();
        Debug.Log($"Бот вышел из состояния: {nameof(Walk)}");
    }

    public void Update()
    {
        if (_mover.IsCompliteMoving() && _stateMachine.ResourceContainer.IsFull == false)
        {
            _stateMachine.TransiteTo<Mining>();
        }
        else if (_mover.IsCompliteMoving() && _stateMachine.ResourceContainer.IsFull)
        {
            _stateMachine.TransiteTo<Drop>();
        }
    }
}