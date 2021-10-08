using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] float runningPenaltyRegenTime = 5f;
    [SerializeField] PlayerStats stats;

    Player player;
    Rigidbody playerRb;
    bool countStats;

    private void Start()
    {
        if(GameDirector.TryGetPlayer(out player))
            playerRb = player.GetComponent<Rigidbody>();


        LoadPlayerStats();
        GamePausedState.gamePaused += CountStatsEnabled;
        countStats = true;
    }

    private void OnDestroy()
    {
        GamePausedState.gamePaused -= CountStatsEnabled;
    }

    void LoadPlayerStats()
    {
        if (stats == null) stats = new PlayerStats();
    }

    void CountStatsEnabled(bool state) => countStats = !state;

    private void Update()
    {
        if (!countStats) return;
        stats.timePlayed += Time.deltaTime;

        if (HidingManager.playerInHiding)
            stats.timeInHiding += Time.deltaTime;

        if (AlienCloseToPlayer())
            stats.alienCloseTime += Time.deltaTime;

        if (playerRb.velocity.magnitude > 5f)
            stats.runningPenaltyAmount += Time.deltaTime;
        else if(stats.runningPenaltyAmount > 0f)
        {
            stats.runningPenaltyAmount -= Time.deltaTime / runningPenaltyRegenTime;
            if (stats.runningPenaltyAmount < 0f)
                stats.runningPenaltyAmount = 0f;
        }
    }

    bool AlienCloseToPlayer()
    {
        if (!GameDirector.alienActive) return false;

        RaycastHit hit;
        Alien alien;
        if (!GameDirector.TryGetAlien(out alien)) return false;

        if (Physics.Linecast(alien.transform.position, player.head.position, out hit, ~LayerMask.GetMask("Alien")))
            if (hit.collider.CompareTag("Player")) return true; 
        return false;
    }

}
