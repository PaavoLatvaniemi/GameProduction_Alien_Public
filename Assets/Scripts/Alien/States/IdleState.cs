using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform food;
    Animator anim;
    AlienVisionController visionController;
    AlienHearingController hearingController;

    Timer patrolTimer;
    bool firstEnter;

    public IdleState(Alien _alien) : base(_alien.gameObject)
    {   
        alien = _alien;
        anim = transform.GetComponent<Animator>();
        visionController = transform.GetComponent<AlienVisionController>();
        nav = transform.GetComponent<NavMeshAgent>();
        hearingController = transform.GetComponent<AlienHearingController>();
        firstEnter = true;
    }

    public override void OnStateEnter()
    {
        nav.speed = alien.config.walkMovementSpeed;
        //anim.SetTrigger("LookAround");
        if (firstEnter)
        {
            firstEnter = false;
            patrolTimer = TimerFactory.CreateTimer(0f);
            return;
        }
        patrolTimer = TimerFactory.CreateTimer(UnityEngine.Random.Range(2f,5f));
    }

    public override void OnStateExit()
    {
        // Stopping look around anim on exit
        anim.CrossFadeInFixedTime("LookAroundIdle", 0.2f);
    }

    public override Type Tick()
    {
        patrolTimer.Tick();
        if (patrolTimer.Finished())
        {
            if (SearchableRooms.RoomsAvailable)
            {
                switch (alien.awarenessLevel)
                {
                    case 0: break;
                    case 1: return typeof(SearchRandomRoomState);
                    case 2: return typeof(SearchRoomWithPlayerInsideState);
                    default: break;
                }
            }

            if (GameDirector.shouldAlienRetreat && alien.awarenessLevel == 0)
                return typeof(RetreatState);

            return typeof(RandomPatrolState);
        }

        if (visionController.targetDetected)
        {
            patrolTimer.Reset();
            return typeof(RoarState);
        }
        if (visionController.targetDetectionCertainty > 0)
            return typeof(SusState);

        if (hearingController.HeardNoise())
        {
            patrolTimer.Reset();
            return typeof(InvestigateNoiseState);
        }
        return null;
    }
}
