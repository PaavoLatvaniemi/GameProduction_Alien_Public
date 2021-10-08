using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimerFactory
{
    static Queue<Timer> pool = new Queue<Timer>();

    public static Timer CreateTimer(float seconds)
    {
        Timer timer = GetTimer();
        timer.SetTimeLeft(seconds);
        return timer;
    }

    private static Timer GetTimer()
    {
        if (pool.Count > 0)
            return pool.Dequeue();
        else
            return new Timer();
    }

    public static void AddToPool(Timer timer) => pool.Enqueue(timer);
}
