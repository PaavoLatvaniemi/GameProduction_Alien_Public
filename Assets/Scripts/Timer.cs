using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float timeLeft { get; private set; }

    public void Tick()
    {
        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;
    }

    public bool Finished()
    {
        if (timeLeft > 0) return false;
        TimerFactory.AddToPool(this);
        return true;
    }

    public void Reset()
    {
        timeLeft = 0f;
        TimerFactory.AddToPool(this);
    }

    public void SetTimeLeft(float time) => timeLeft = time;
}
