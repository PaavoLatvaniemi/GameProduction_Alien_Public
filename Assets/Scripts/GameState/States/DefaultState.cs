using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BaseState
{
    GameStateManager manager;
    public DefaultState(GameStateManager stateManager) : base(stateManager.gameObject)
    {
        manager = stateManager;
    }

    public override Type Tick()
    {
        return null;
    }
}
