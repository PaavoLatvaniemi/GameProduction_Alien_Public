using UnityEngine;
using UnityEngine.AI;
using System;

public class RoarState : BaseState 
{
    Alien alien;
    NavMeshAgent nav;
    Animator animationAlien;
    Timer roarAnimationTimer;
    Transform player;

    public RoarState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        nav = transform.GetComponent<NavMeshAgent>();
        animationAlien = transform.GetComponent<Animator>();
        player = GameDirector.player.transform;
    }

    public override void OnStateEnter()
    {
        animationAlien.CrossFadeInFixedTime("Roar", 0.2f);
        nav.ResetPath();

        roarAnimationTimer = TimerFactory.CreateTimer(2.5f);
    }

    public override Type Tick()
    {
        //Debug.Log("Roar");

        // Alien rotates toward player
        Vector3 targetDirection = player.position - transform.position;
        float singleStep = alien.config.lookRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        roarAnimationTimer.Tick();
        if (roarAnimationTimer.Finished()) return typeof(ChaseState);

        return null;            
    }
}
