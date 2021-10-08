using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseToHidingState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform player;
    Animator anim;
    Timer killTimer;

    public ChaseToHidingState(Alien _alienController) : base(_alienController.gameObject)
    {
        alien = _alienController;
        player = GameDirector.player.transform;
        nav = transform.GetComponent<NavMeshAgent>();
        anim = transform.GetComponent<Animator>();
    }

    public override void OnStateEnter()
    {
        Vector3 hidingSpotPos = HidingManager.currentHidingSpot.killPosition.position;
        nav.SetDestination(hidingSpotPos);
        nav.stoppingDistance = 0f;
        killTimer = TimerFactory.CreateTimer(1f);
    }

    public override void OnStateExit()
    {
        nav.stoppingDistance = 2f;
    }

    public override Type Tick()
    {
        if (!HidingManager.playerInHiding) return typeof(ChaseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;

        if (!nav.pathPending && InStoppingDistance)
        {
            RotateTowardsPlayer();
            killTimer.Tick();
            if (killTimer.Finished() || HidingManager.currentHidingSpot.doorOpen)
            {               
                HidingManager.currentHidingSpot.OpenHidingSpotDoor();
                if (alien.config.canKillPlayer)
                    return typeof(KillState);
            }
        }
        return null;
    }

    void RotateTowardsPlayer()
    {
        Vector3 targetDirection = player.position - transform.position;
        float singleStep = alien.config.lookRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
