using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SusState : BaseState
{

    Alien alien;
    NavMeshAgent nav;
    Transform food;
    Animator anim;
    AlienVisionController visionController;
    Transform player;


    bool firstEnter;
    public SusState(Alien _alien) : base(_alien.gameObject)
    {
        alien = _alien;
        player = GameDirector.player.transform;
        anim = transform.GetComponent<Animator>();
        visionController = transform.GetComponent<AlienVisionController>();
        nav = transform.GetComponent<NavMeshAgent>();

    }
    public override void OnStateEnter()
    {
        //anim.CrossFadeInFixedTime("sus", 0.2f);
        anim.SetBool("Sus", true);
        nav.speed = 2f;
        nav.SetDestination(player.position);

    }
    public override void OnStateExit()
    {
        anim.SetBool("Sus", false);
        nav.ResetPath();
    }

    
    public override Type Tick()
    {

        // Alien rotates toward player
        /*
        Vector3 targetDirection = player.position - transform.position;
        float singleStep = alien.config.lookRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);*/

        if (visionController.targetDetected)
        {
            // Go get 'em boy!
            return typeof(RoarState);
        }


        else if (visionController.targetDetectionCertainty <= 0)
        {
            // Stop sus and go back to IdleState
            return typeof(IdleState);
        }

        return null;
        
        
    }
}
