using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    StateMachine stateMachine;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {         
            { typeof(DefaultState), new DefaultState(this) },
            { typeof(GamePausedState), new GamePausedState(this) },
        };

        stateMachine.SetStates(states);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(stateMachine.CurrentState.GetType() == typeof(GamePausedState))
                stateMachine.SwitchToNewState(typeof(DefaultState));
            else
                stateMachine.SwitchToNewState(typeof(GamePausedState));
        }
    }
}
