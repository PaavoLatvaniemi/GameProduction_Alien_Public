using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillState : BaseState
{
    Alien alien;
    NavMeshAgent nav;
    Transform player;
    Animator anim;

    public KillState(Alien _alienController) : base(_alienController.gameObject)
    {
        alien = _alienController;
        player = GameDirector.player.transform;
        nav = transform.GetComponent<NavMeshAgent>();
        anim = transform.GetComponent<Animator>();
    }

    public override void OnStateEnter()
    {
        nav.ResetPath();
        nav.SetDestination(transform.position);
        anim.CrossFadeInFixedTime("Attack", .2f);
        GameDirector.player.StartKillSequence();
    }

    public override Type Tick()
    {
        Vector3 targetDirection = player.position - transform.position;
        float singleStep = alien.config.lookRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        return null;
    }
}
