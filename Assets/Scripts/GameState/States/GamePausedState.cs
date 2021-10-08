using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : BaseState
{
    GameStateManager manager;
    public static event Action<bool> gamePaused;
    public GamePausedState(GameStateManager stateManager) : base(stateManager.gameObject)
    {
        manager = stateManager;
    }

    public override void OnStateEnter()
    {
        gamePaused?.Invoke(true);
    }

    public override void OnStateExit()
    {
        gamePaused?.Invoke(false);
    }
    public override Type Tick()
    {
        return null;
    }
}
