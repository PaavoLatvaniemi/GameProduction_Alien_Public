using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchRoomWithPlayerInsideState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    SearchableRoomBehaviour room;
    Vector3 randomPosition;

    AlienVisionController visionController;
    AlienHearingController hearingController;

    public SearchRoomWithPlayerInsideState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        nav = transform.GetComponent<NavMeshAgent>();
        visionController = transform.GetComponent<AlienVisionController>();
        hearingController = transform.GetComponent<AlienHearingController>();
    }
    public override void OnStateEnter()
    {
        room = SearchableRooms.GetAvailableRoomWithPlayerInside();
        if (room != null)
        {
            randomPosition = room.transform.position + UnityEngine.Random.insideUnitSphere * room.SearchingRadius;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPosition, out hit, room.SearchingRadius, NavMesh.AllAreas))
            {
                nav.SetDestination(hit.position);
            }
        }
    }

    public override Type Tick()
    {
        if (room == null) return typeof(SearchRandomRoomState);

        if (visionController.targetDetected)
            return typeof(RoarState);
        
        if (visionController.targetDetectionCertainty > 0)
            return typeof(SusState);

        if (hearingController.HeardNoise())
            return typeof(InvestigateNoiseState);

        bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;
        if (!nav.pathPending && InStoppingDistance)
        {
            room.SetIsSearched(true);
            return typeof(IdleState);
        }  
        return null;
    }
}
