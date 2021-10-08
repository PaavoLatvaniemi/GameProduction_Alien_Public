using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HidingManager
{
    public static bool playerInHiding { get; private set; }
    public static HidingSpot currentHidingSpot;

    public static void PlayerEnterHiding(HidingSpot hidingSpot)
    {
        currentHidingSpot = hidingSpot;
        playerInHiding = true;
    }

    public static void PlayerResetHiding() 
    {
        playerInHiding = false;
    }
}
