
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InvestigateNoiseState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform player;
    Animator animationAlien;
    AlienVisionController visionController;
    AlienHearingController hearingController;

    public InvestigateNoiseState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        player = GameDirector.player.transform;
        nav = transform.GetComponent<NavMeshAgent>();
        animationAlien = transform.GetComponent<Animator>();
        visionController = transform.GetComponent<AlienVisionController>();
        hearingController = transform.GetComponent<AlienHearingController>();
    }

    public override void OnStateEnter()
    {
        nav.speed = alien.config.investigateMovementSpeed;
        nav.SetDestination(hearingController.LastHeardNoisePos);
    }

    public override Type Tick()
    {
        if (hearingController.HeardNoiseFromPlayer())
        {
            if (HidingManager.playerInHiding)
            {
                if(Vector3.Distance(transform.position, player.position) <= 8f)
                    return typeof(ChaseToHidingState);
            }
        }

        if (visionController.targetDetected)
            return typeof(ChaseState);

        if (visionController.targetDetectionCertainty > 0)
            return typeof(SusState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;
        if (!nav.pathPending && InStoppingDistance)
            return typeof(IdleState);

        return null;
    }
}
