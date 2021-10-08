using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform player;
    AlienVisionController visionController;
    AlienHearingController hearingController;

    public HuntState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        player = GameDirector.player.transform;
        nav = transform.GetComponent<NavMeshAgent>();
        visionController = transform.GetComponent<AlienVisionController>();
        hearingController = transform.GetComponent<AlienHearingController>();
    }

    public override void OnStateEnter()
    {
        nav.speed = alien.config.huntMovementSpeed;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        NavMeshHit huntDestination;
        if (NavMesh.SamplePosition(player.position, out huntDestination, distanceToPlayer / alien.config.huntInstinct, NavMesh.AllAreas))
            nav.SetDestination(huntDestination.position);
    }

    public override Type Tick()
    {
        //Debug.Log("Hunt");

        if (visionController.targetDetected)
            return typeof(ChaseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;

        if (!nav.pathPending && InStoppingDistance)
            return typeof(IdleState);

        if (hearingController.HeardNoise())
            return typeof(InvestigateNoiseState);

        return null;
    }
}
