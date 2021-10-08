using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RetreatState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    RetreatRouteBehaviour retreatRoute;
    AlienVisionController visionController;
    AlienHearingController hearingController;
    public RetreatState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        nav = transform.GetComponent<NavMeshAgent>();
        visionController = transform.GetComponent<AlienVisionController>();
        hearingController = transform.GetComponent<AlienHearingController>();
    }

    public override void OnStateEnter()
    {
        retreatRoute = RetreatRoutes.GetClosestRoute(transform);
        if(retreatRoute != null)
        {
            nav.SetDestination(retreatRoute.transform.position);
        }
    }

    public override Type Tick()
    {
        if (retreatRoute == null)
            Retreat();

        if (visionController.targetDetected)
            return typeof(RoarState);

        if (visionController.targetDetectionCertainty > 0)
            return typeof(SusState);

        if (hearingController.HeardNoise())
            return typeof(InvestigateNoiseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;
        if (!nav.pathPending && InStoppingDistance)
            Retreat();

        return null;
    }

    void Retreat()
    {
        GameDirector.shouldAlienRetreat = false;
        GameDirector.SetAlienActive(false);
    }
}
