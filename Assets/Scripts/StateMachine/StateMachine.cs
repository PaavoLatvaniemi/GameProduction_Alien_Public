using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> availableStates;

    public BaseState CurrentState { get; private set; }

    public delegate void StateChange();
    public event StateChange OnStateChanged;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        availableStates = states;
    }

    private void OnDisable()
    {
        CurrentState = null;
    }

    private void Update()
    {
        if(CurrentState == null)
        {
            CurrentState = availableStates.Values.First();
            CurrentState.OnStateEnter();
        }

        var nextState = CurrentState?.Tick();

        if(nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    public void SwitchToNewState(Type nextState) 
    {
        CurrentState.OnStateExit();
        CurrentState = availableStates[nextState];
        CurrentState.OnStateEnter();
        OnStateChanged?.Invoke();
    }
}
