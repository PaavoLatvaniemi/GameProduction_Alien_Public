using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrolState : BaseState
{
    Alien alien;
    NavMeshAgent nav;

    AlienVisionController visionController;
    AlienHearingController hearingController;

    float range = 25f;

    bool atPatrolCheckpoint;

    Vector3 randomPosition;

    public RandomPatrolState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        nav = transform.GetComponent<NavMeshAgent>();
        visionController = transform.GetComponent<AlienVisionController>();
        hearingController = transform.GetComponent<AlienHearingController>();


    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * range;
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, range, NavMesh.AllAreas))
        {
            nav.SetDestination(hit.position);
        }

    }
    public override void OnStateExit()
    {

        base.OnStateExit();
    }

    public override Type Tick()
    {
        if (visionController.targetDetected)
            return typeof(RoarState);

        if (visionController.targetDetectionCertainty > 0)
            return typeof(SusState);

        if (hearingController.HeardNoise())
            return typeof(InvestigateNoiseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;

        if (!nav.pathPending && InStoppingDistance)
            return typeof(IdleState);

        //if(nav.pathStatus == NavMeshPathStatus.PathComplete )
            //return typeof(IdleState);

        return null;
    }
}
