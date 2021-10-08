using System;
using UnityEngine;

public abstract class BaseState
{
    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
    }
    protected GameObject gameObject;
    protected Transform transform;
    public abstract Type Tick();

    public virtual void OnStateExit()
    {

    }

    public virtual void OnStateEnter()
    {

    }

}
