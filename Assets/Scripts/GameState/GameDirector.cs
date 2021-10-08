using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDirector
{
    public static bool alienActive;

    // Should Alien retreat when not aware of the player
    public static bool shouldAlienRetreat;
    public static Alien alien { get; private set; }
    public static Player player { get; private set; }
    public static void AssignPlayer(Player instance) => player = instance;
    public static void AssignAlien(Alien instance)
    {
        alien = instance;
        SetAlienActive(false);
    }

    public static bool TryGetPlayer(out Player outPlayer)
    {
        if (player != null) 
        {
            outPlayer = player;
            return true;
        }
        outPlayer = null;
        return false;
    }
    public static bool TryGetAlien(out Alien outAlien)
    {
        if (player != null)
        {
            outAlien = alien;
            return true;
        }
        outAlien = null;
        return false;
    }
    public static void SetAlienActive(bool state)
    {
        if (alien == null) return;
        alien.gameObject.SetActive(state);
        alienActive = state;
    }  
}
