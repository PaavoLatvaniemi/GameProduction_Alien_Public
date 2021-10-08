using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    [SerializeField] AlienConfig _config;
    public Transform killCamLookTarget;
    public AlienConfig config => _config;
    StateMachine stateMachine;
    Animator anim;
    NavMeshAgent nav;
    // Awareness Levels
    // 0 - None
    // 1 - Search random rooms
    // 2 - Search room where player is
    public int awarenessLevel = 0;
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        InitializeStateMachine();
        GameDirector.AssignAlien(this);
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(IdleState), new IdleState(this) },
            { typeof(RoarState), new RoarState(this) },
            { typeof(ChaseState), new ChaseState(this) },
            { typeof(HuntState), new HuntState(this) },
            { typeof(InvestigateNoiseState), new InvestigateNoiseState(this) },
            { typeof(KillState), new KillState(this) },
            { typeof(RandomPatrolState), new RandomPatrolState(this) },
            { typeof(ChaseToHidingState), new ChaseToHidingState(this) },
            { typeof(SearchRandomRoomState), new SearchRandomRoomState(this) },
            { typeof(SearchRoomWithPlayerInsideState), new SearchRoomWithPlayerInsideState(this) },
            { typeof(RetreatState), new RetreatState(this) },
            { typeof(SusState), new SusState(this) },
            //- Add new state to StateMachine
            //{ typeof(StateClass), new StateClass(this) },
        };

        stateMachine.SetStates(states);
    }

    private void Update()
    {
        SetAnimVelocityMagnitude(nav.velocity.magnitude);
    }

    public void SetAnimVelocityMagnitude(float magnitude)
    {
        float velocityMagnitude = magnitude / config.maxMovementSpeed;
        anim.SetFloat("Velocity", velocityMagnitude, 0.1f, Time.deltaTime);
    }

    public void SetAwarnessLevelPermanent(int level)
    {
        awarenessLevel = level;
    }

    public void ResetAwarnessLevel()
    {
        awarenessLevel = 0;
    }

    public void SetAwarenessLevelTwo(float duration)
    {
        awarenessLevel = 2;
        StartCoroutine(AwarenessLevelCoroutine(duration));
    }

    public void SetAwarenessLevelOne(float duration)
    {
        awarenessLevel = 1;
        Invoke("ResetIsAwareOfPlayer", duration);
    }

    IEnumerator AwarenessLevelCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        SetAwarenessLevelOne(duration);
    }

    void ResetIsAwareOfPlayer() => awarenessLevel = 0;
}
