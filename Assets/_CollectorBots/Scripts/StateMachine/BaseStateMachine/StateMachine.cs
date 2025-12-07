using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour, IStateMachine
{
    private IState _currentState;
    private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

    protected virtual void Update() =>
        _currentState?.Update();

    public T GetCurrentState<T>() where T : IState
    {
        return (T)_currentState;
    }

    public void TransiteTo<T>() where T : IState
    {
        _currentState?.Exit();

        var type = typeof(T);

        if (_states.TryGetValue(type, out IState state))
        {
            _currentState = state;
            _currentState.Enter();
        }
        else
        {
            Debug.LogError($"State {type.Name} not found!");
        }
    }

    protected void AddState<T>(IState state) where T : IState
    {
        _states.Add(typeof(T), state);
    }
}