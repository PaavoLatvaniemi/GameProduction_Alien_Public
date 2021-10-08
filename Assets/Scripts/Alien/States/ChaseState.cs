using System;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform player;
    Animator anim;
    AlienVisionController visionController;
    KillRange killRange;

    public ChaseState(Alien _alienController) : base(_alienController.gameObject)
    {
        alien = _alienController;
        player = GameDirector.player.transform;
        nav = transform.GetComponent<NavMeshAgent>();
        anim = transform.GetComponent<Animator>();
        visionController = transform.GetComponent<AlienVisionController>();
        killRange = transform.GetComponentInChildren<KillRange>();
    }

    public override void OnStateEnter()
    {
        nav.speed = alien.config.chaseMovementSpeed;
    }

    public override Type Tick()
    {
        //Debug.Log("Chase");
        nav.SetDestination(player.position);

        if (HidingManager.playerInHiding) return typeof(ChaseToHidingState);

        if (!visionController.targetDetected && !PlayerInDetectionRange())
        {
            bool InStoppingDistance = nav.remainingDistance <= nav.stoppingDistance;
            if (!nav.pathPending && InStoppingDistance)
                return typeof(HuntState);
            return null;
        }

        if(alien.config.canKillPlayer)
            if (killRange.inKillRange) return typeof(KillState);
    
        return null;
    }

    bool PlayerInDetectionRange()
    {
        if (Vector3.Distance(transform.position, player.position) > alien.config.minEscapeDistance) return false;
        return true;
    }

}
